using GreenPipes;
using MassTransit;
using MassTransitExampleProject.Common;
using MassTransitExampleProject.MessageContracts;
using System;

namespace MassTransitExampleProject.SmsNotification
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "SMS Notification";

            var bus = BusConfigurator
               .ConfigureBus((cfg) =>
               {
                   cfg.ReceiveEndpoint(RabbitMqConsts.SmsNotificationServiceQueue, e =>
                   {
                       e.Consumer<SmsNotificationEventConsumer>();
                       e.UseMessageRetry(r => r.Immediate(5));     //Hata çıkarsa 5dk da bir mesajı tekrar at 
                                                                   //MassTransit mesajlarda kayba uğramamak ile birlikte queue akışını da bozmamak adına hata aldığı mesajları, [hata aldığı queue ismi].error adında bir queue oluşturup buraya atmaktadır.
                   });
               });

            bus.StartAsync();
            Console.WriteLine("Listening for SMS Notification events.. Press enter to exit");
            Console.ReadLine();
            bus.StopAsync();
        }
    }
}
