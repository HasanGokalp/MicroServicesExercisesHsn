using MassTransit;
using Microsoft.AspNetCore.Mvc;
using PaymentSys.Payment.Models;
using PaymentSys.Shared.Messages;
using Address = PaymentSys.Shared.Messages.Address;

namespace PaymentSys.Payment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;
        public PaymentController(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        [HttpGet("GetAllPayment")]
        public IActionResult GetAllPayment()
        {
            return Ok("Not Implemented");
        }
        [HttpPost("ReceivePayment")]
        public async Task<IActionResult> ReceivePayment(PaymentDto paymentDto)
        {
            var send = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:create-order-service"));

            var entity = new CreateOrderMessageCommand
            {
                Id = paymentDto.Id,
                Name = paymentDto.Name,
                Address = new Address
                {
                    Street = paymentDto.OrderDto.Address.Street,
                    Apartment = paymentDto.OrderDto.Address.Apartment
                }
            };

            await send.Send<CreateOrderMessageCommand>(entity);

            return Ok("look at que");
        }
    }
}
