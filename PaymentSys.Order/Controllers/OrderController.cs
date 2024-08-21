using Microsoft.AspNetCore.Mvc;

namespace PaymentSys.Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        [HttpGet]
        public IActionResult GetAllOrder()
        {
            return Ok("Not Implemented");
        }
    }
}
