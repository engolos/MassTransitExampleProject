using GreenPipes;
using MassTransit;
using MassTransitExampleProject.Common;
using MassTransitExampleProject.MessageContracts;
using System;

namespace MassTransitExampleProject.MailNotification
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "E-MAIL Notification";
            var bus = BusConfigurator
               .ConfigureBus((cfg) =>
               {
                   cfg.ReceiveEndpoint(RabbitMqConsts.MailNotificationServiceQueue, e =>
                   {
                       e.Consumer<MailNotificationEventConsumer>();
                       e.UseRateLimit(1000, TimeSpan.FromMinutes(1));              //Belirli Bir Süre İçerisinde İşlenecek Mesaj Adedini Belirleme
                   });
               });
            bus.StartAsync();
            Console.WriteLine("Listening for Order e-mail events.. Press enter to exit");
            Console.ReadLine();
            bus.StopAsync();
        }
    }
}
