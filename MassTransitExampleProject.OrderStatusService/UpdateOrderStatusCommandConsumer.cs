using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransitExampleProject.MessageContracts;

namespace MassTransitExampleProject.OrderStatusService
{
    public class UpdateOrderStatusCommandConsumer : IConsumer<IUpdateOrderStatusCommand>
    {
        public async Task Consume(ConsumeContext<IUpdateOrderStatusCommand> context)
        {
            var orderCommand = context.Message;

            await Console.Out.WriteAsync($"Order Id: {orderCommand.OrderId} Order status: {orderCommand.OrderStatus}");

            //do something..

            string OrderMessgae = "Order Id: " + orderCommand.OrderId.ToString() + "Order status: " + orderCommand.OrderStatus.ToString();

            await context.Publish<IOrderStatusChangedEvent>(new
            {
                orderCommand.OrderId,
                orderCommand.OrderStatus,
                OrderMessgae
            });

        }
    }
}
