using Microsoft.AspNetCore.Mvc;

namespace PlayNirvanaTechExam.Interfaces.Services;

public interface IRequestQueueService
{
    Task<IActionResult> EnqueueRequest(string userId, Func<Task<IActionResult>> request);
}