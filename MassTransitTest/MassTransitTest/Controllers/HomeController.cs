using MassTransit;
using MassTransitTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace MassTransitTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        readonly IBus _bus;
        public HomeController(IBus bus)
        {
            _bus = bus;
        }

        [HttpGet]
        public async Task<IActionResult> Publish()
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri("queue:otusqueue"));
            await endpoint.Send(new OtusMessage()
            {
                Name = "test!!!"
            });
            return Ok();
        }
    }
}
