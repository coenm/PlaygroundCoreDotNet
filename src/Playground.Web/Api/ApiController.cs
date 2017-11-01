using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Playground.Calculator;

namespace Playground.Web.Api
{
    [Controller]
    [Route("api")]
    public class ApiController
    {
        private readonly IDateTimeProvider _dateTimeProvider;

        public ApiController(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        [Route("sayhelloworld/{name}")]
        [HttpGet]
        public async Task<IActionResult> SayHelloWorldAsync(string name)
        {
            await Task.Delay(10);
            var response = _dateTimeProvider.Now.ToString("HHmmss ") + name;
            return new OkObjectResult(response);
        }
       

        [Route("greetings/count")]
        [HttpGet]
        public async Task<IActionResult> GetTotalNumberOfGreetingsAsync()
        {
            await Task.Delay(100);

            return new OkObjectResult(2);
        }
    }
}