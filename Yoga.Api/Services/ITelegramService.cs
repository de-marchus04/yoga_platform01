using System.Threading.Tasks;
using Yoga.Shared.Models;

namespace Yoga.Api.Services
{
    public interface ITelegramService
    {
        Task SendLeadNotificationAsync(Lead lead);
    }
}
