using Microsoft.AspNetCore.Mvc;

namespace PlayNirvanaTechExam.Dtos;

public class QueueRequest
{
    public string UserId { get; set; } = null!;
    public Func<Task<IActionResult>> Request { get; set; } = null!;
    public TaskCompletionSource<IActionResult> CompletionSource { get; set; } = null!;
}