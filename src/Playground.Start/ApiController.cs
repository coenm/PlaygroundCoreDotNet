using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace Playground.Start
{
    [Controller]
    [Route("api")]
    public class ApiController
    {
        private readonly ILogger _logger;
        private static readonly ILogger Log = LogManager.GetCurrentClassLogger();
        
        [Route("sayhelloworld/{name}")]
        [HttpGet]
        public async Task<IActionResult> SayHelloWorldAsync(string name)
        {
            Log.Info("'sayhelloworld' Request received with '{0}'.", name);

            await Task.Delay(10);

            var response = new HelloRsp
            {
                Name = $"{name} abc"
            };

            return new OkObjectResult(response);
        }
       

        [Route("greetings/count")]
        [HttpGet]
        public async Task<IActionResult> GetTotalNumberOfGreetingsAsync()
        {
            Log.Info("'greetings/count' Request received.");

            await Task.Delay(100);

            return new OkObjectResult(2);
        }
    }
}