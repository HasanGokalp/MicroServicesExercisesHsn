using MassTransit;
using PaymentSys.Order.Context;
using PaymentSys.Shared.Messages;
using Address = PaymentSys.Order.Models.Address;

namespace PaymentSys.Order.Consumer
{
    public class CreateOrderMessageCommandConsumer : IConsumer<CreateOrderMessageCommand>
    {
        public async Task Consume(ConsumeContext<CreateOrderMessageCommand> context)
        {
            var ctx = new PaymentSysOrderCtx();

            Order.Models.Order ord = new Models.Order();
            ord.Id = context.Message.Id;
            ord.Name = context.Message.Name;
            ord.Address = new Address
            {
                Street = context.Message.Address.Street,
                Apartment = context.Message.Address.Apartment
            };

            await ctx.Orders.AddAsync(ord);
            await ctx.SaveChangesAsync();
        }
    }
}
