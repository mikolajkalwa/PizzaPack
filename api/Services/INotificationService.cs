using System.Threading.Tasks;
using api.Models;
using SendGrid;

namespace api.Services
{
    public interface INotificationService
    {
        Task SendNotification(string receiver, Order order);
    }
}