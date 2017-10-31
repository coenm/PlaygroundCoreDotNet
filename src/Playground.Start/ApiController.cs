using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Playground.Start
{
    [Controller]
    [Route("api")]
    public class ApiController
    {
        [Route("sayhelloworld/{name}")]
        [HttpGet]
        public async Task<IActionResult> SayHelloWorldAsync(string name)
        {
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
            await Task.Delay(100);

            return new OkObjectResult(2);
        }
    }
}