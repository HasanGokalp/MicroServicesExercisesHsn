using Microsoft.AspNetCore.Mvc;
using PaymentSys.Web.Models.Dtos;
using System.Text.Json;
using System.Text;

namespace PaymentSys.Web.Controllers
{
    public class PaymentController : Controller
    {
        [HttpGet]
        public IActionResult ReceivePayment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ReceivePayment(PaymentDto paymentDto)
        {
            var client = new HttpClient();
            // Nesneyi JSON formatına çeviriyoruz
            var json = JsonSerializer.Serialize(paymentDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // POST isteğini gönderiyoruz
            var response = await client.PostAsync("http://localhost:5000/services/Payment/Receivepayment", content);
            return View();
        }
    }
}
