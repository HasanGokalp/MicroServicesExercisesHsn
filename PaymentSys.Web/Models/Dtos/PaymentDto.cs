namespace PaymentSys.Web.Models.Dtos
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public OrderDto OrderDto { get; set; }
    }
}
