namespace Playground.Web.Api
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Playground.Calculator;

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
            await Task.Delay(10); // dummy processing time
            var response = _dateTimeProvider.Now.ToString("HHmmss ") + name;
            return new OkObjectResult(response);
        }


        [Route("greetings/count")]
        [HttpGet]
        public async Task<IActionResult> GetTotalNumberOfGreetingsAsync()
        {
            await Task.Delay(100); // dummy processing time
            return new OkObjectResult(2);
        }
    }
}