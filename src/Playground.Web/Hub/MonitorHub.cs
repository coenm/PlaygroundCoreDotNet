namespace Playground.Web.Hub
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.SignalR;

    using Playground.Calculator;

    public class MonitorHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public MonitorHub(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }
        public Task Send(string message)
        {
            var msg = _dateTimeProvider.Now.ToString("HH:mm:ss") + " " + message;
            return Clients.All.InvokeAsync("Send", msg);
        }
    }
}