using MassTransit;
using MassTransitExampleProject.MessageContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransitExampleProject.SmsNotification
{
    public class SmsNotificationEventConsumer : IConsumer<IOrderStatusChangedEvent>
    {
        public async Task Consume(ConsumeContext<IOrderStatusChangedEvent> context)
        {
            await Console.Out.WriteLineAsync($"SMS Notification sent: Order id {context.Message.OrderId}");
        }
    }
}
