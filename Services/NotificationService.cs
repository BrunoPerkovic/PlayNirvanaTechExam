using Microsoft.AspNetCore.SignalR;
using PlayNirvanaTechExam.Hub;
using PlayNirvanaTechExam.Interfaces.Services;

namespace PlayNirvanaTechExam.Services;

public class NotificationService : INotificationService
{
    private readonly IHubContext<SearchHub> _hubContext;

    public NotificationService(IHubContext<SearchHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task NotifySearchPerformed(string controller, string action, string searchQuery, string ipAddress, object? response)
    {
        await _hubContext.Clients.All.SendAsync("ReceiveSearchInfo", controller, action, searchQuery, ipAddress, DateTime.UtcNow, response);
    }
}