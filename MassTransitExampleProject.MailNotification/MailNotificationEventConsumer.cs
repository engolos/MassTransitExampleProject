using MassTransit;
using MassTransitExampleProject.MessageContracts;
using System;
using System.Threading.Tasks;

namespace MassTransitExampleProject.MailNotification
{
    public class MailNotificationEventConsumer : IConsumer<IOrderStatusChangedEvent>
    {
        public async Task Consume(ConsumeContext<IOrderStatusChangedEvent> context)
        {
            await Console.Out.WriteLineAsync($"Mail integratin done: Order id {context.Message.OrderId}");
        }
    }
}
