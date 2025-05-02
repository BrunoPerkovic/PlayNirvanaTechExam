using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PlayNirvanaTechExam.Interfaces.Services;

namespace PlayNirvanaTechExam.Extensions;

public class QueueRequestAttribute : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var queueService = context.HttpContext.RequestServices.GetRequiredService<IRequestQueueService>();
        var userId = context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)
            ?.Value;

        if (string.IsNullOrEmpty(userId))
        {
            await next();
            return;
        }

        var result = await queueService.EnqueueRequest(userId, async () =>
        {
            var executedContext = await next();
            return executedContext.Result as IActionResult ?? new StatusCodeResult(500);
        });

        context.Result = result;
    }
}