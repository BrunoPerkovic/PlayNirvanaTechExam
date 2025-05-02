using Microsoft.AspNetCore.SignalR;

namespace PlayNirvanaTechExam.Hub;

public class SearchHub : Microsoft.AspNetCore.SignalR.Hub
{
    public async Task SendSearchInfo(string searchQuery, string ipAddress, DateTime timestamp)
    {
        await Clients.All.SendAsync("ReceiveSearchInfo", searchQuery, ipAddress, timestamp);
    }
}