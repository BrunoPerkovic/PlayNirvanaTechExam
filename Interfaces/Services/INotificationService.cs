namespace PlayNirvanaTechExam.Interfaces.Services;

public interface INotificationService
{
    Task NotifySearchPerformed(string controller, string action, string searchQuery, string ipAddress, object? response);
}