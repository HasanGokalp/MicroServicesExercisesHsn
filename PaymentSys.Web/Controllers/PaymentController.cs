using Microsoft.AspNetCore.Mvc;
using PaymentSys.Web.Models.Dtos;
using System.Text.Json;
using System.Text;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

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
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback =
                (HttpRequestMessage httpRequestMessage, X509Certificate2 cert, X509Chain cetChain, SslPolicyErrors sslPolicyErrors) => true;

            using var client = new HttpClient(handler);
            // Nesneyi JSON formatına çeviriyoruz
            var json = JsonSerializer.Serialize(paymentDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // POST isteğini gönderiyoruz
            var response = await client.PostAsync("https://localhost:5000/services/payment/Payment/Receivepayment", content);
            return View();
        }
    }
}
