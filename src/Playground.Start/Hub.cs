using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using NLog;

namespace Playground.Start
{
    public class ChatHub : Hub
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public Task Send(string message)
        {
            _logger.Info(() => $"Send msg: {message}.");
            return Clients.All.InvokeAsync("Send", message);
        }
    }
}
