using CrossCuttingLayer;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IBus _bus;

        public TodoController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(Todo todo)
        {
            if (todo is not null)
            {
                Uri uri = new Uri(RabbitMqConstants.RabbitMqUri);
                var endpoint = await _bus.GetSendEndpoint(uri);
                await endpoint.Send(todo);
                return Ok();
            }

            return BadRequest();
        }
    }
}
