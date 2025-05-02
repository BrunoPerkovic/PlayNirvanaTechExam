using Microsoft.AspNetCore.Mvc;
using PlayNirvanaTechExam.Dtos;
using PlayNirvanaTechExam.Interfaces.Services;

namespace PlayNirvanaTechExam.Services;

public class RequestQueueService : IRequestQueueService
{
    private readonly Dictionary<string, Queue<QueueRequest>> _userQueues = new();
    private readonly Dictionary<string, Task> _processingTasks = new();
    private readonly object _lock = new();

    public async Task<IActionResult> EnqueueRequest(string userId, Func<Task<IActionResult>> request)
    {
        var queuedRequest = new QueueRequest
        {
            UserId = userId,
            Request = request,
            CompletionSource = new TaskCompletionSource<IActionResult>()
        };

        lock (_lock)
        {
            if (!_userQueues.ContainsKey(userId))
            {
                _userQueues[userId] = new Queue<QueueRequest>();
                _processingTasks[userId] = ProcessUserQueue(userId);
            }

            _userQueues[userId]
                .Enqueue(queuedRequest);
        }

        return await queuedRequest.CompletionSource.Task;
    }

    private async Task ProcessUserQueue(string userId)
    {
        while (true)
        {
            QueueRequest? request;
            lock (_lock)
            {
                if (_userQueues[userId].Count == 0)
                {
                    _userQueues.Remove(userId);
                    _processingTasks.Remove(userId);
                    return;
                }

                request = _userQueues[userId]
                    .Dequeue();
            }

            try
            {
                var result = await request.Request();
                request.CompletionSource.SetResult(result);
            }
            catch (Exception ex)
            {
                request.CompletionSource.SetException(ex);
            }
        }
    }
}