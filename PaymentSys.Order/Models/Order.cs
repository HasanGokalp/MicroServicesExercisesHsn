﻿namespace PaymentSys.Order.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}
