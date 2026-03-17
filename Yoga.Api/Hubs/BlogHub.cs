using Microsoft.AspNetCore.SignalR;

namespace Yoga.Api.Hubs
{
    /// <summary>
    /// Real-time hub for blog content updates.
    /// Clients subscribe and receive "BlogUpdated" events with the affected sections array.
    /// </summary>
    public class BlogHub : Hub
    {
    }
}
