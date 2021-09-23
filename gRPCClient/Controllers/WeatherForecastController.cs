using Grpc.Net.Client;
using GrpcGreeter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gRPCClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:50051");
            var client = new Greeter.GreeterClient(channel);

            var response = await client.SayHelloAsync(
                new HelloRequest { Name = "World" });
            
            return Ok(response.Message);
        }
    }
}
