namespace PaymentSys.Payment.Models
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public OrderDto OrderDto { get; set; }
    }
}
