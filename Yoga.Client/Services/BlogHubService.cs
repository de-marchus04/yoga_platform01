using Microsoft.AspNetCore.SignalR.Client;

namespace Yoga.Client.Services
{
    /// <summary>
    /// Singleton SignalR client that listens to the BlogHub for live content updates.
    /// Components subscribe to OnBlogUpdated and re-fetch when their section is affected.
    /// </summary>
    public sealed class BlogHubService : IAsyncDisposable
    {
        private HubConnection? _connection;

        public event Action<string[]>? OnBlogUpdated;

        /// <summary>
        /// Starts the hub connection idempotently. Safe to call from multiple components.
        /// </summary>
        public async Task EnsureStartedAsync(string apiBaseUrl)
        {
            if (_connection != null) return;

            _connection = new HubConnectionBuilder()
                .WithUrl(apiBaseUrl.TrimEnd('/') + "/blogHub")
                .WithAutomaticReconnect()
                .Build();

            _connection.On<string[]>("BlogUpdated", sections =>
                OnBlogUpdated?.Invoke(sections));

            try
            {
                await _connection.StartAsync();
            }
            catch
            {
                // Hub unreachable (offline / initial dev setup) — degrade gracefully
                _connection = null;
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_connection != null)
                await _connection.DisposeAsync();
        }
    }
}
