namespace PaymentSys.Web.Models.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }

        public string Apartment { get; set; }
    }
}
