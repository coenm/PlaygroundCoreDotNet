using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Playground.Web.Hub
{
    public class MonitorHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public Task Send(string message)
        {
            return IClientProxyExtensions.InvokeAsync(Clients.All, "Send", message);
        }
    }
}