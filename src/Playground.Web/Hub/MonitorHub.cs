using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Playground.Calculator;

namespace Playground.Web.Hub
{
    public class MonitorHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public MonitorHub(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }
        public Task Send(string message)
        {
            return IClientProxyExtensions.InvokeAsync(Clients.All, "Send", _dateTimeProvider.Now.ToString("HH:mm:ss") + " " + message);
        }
    }
}