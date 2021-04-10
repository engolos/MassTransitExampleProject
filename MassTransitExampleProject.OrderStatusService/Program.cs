using GreenPipes;
using MassTransit;
using MassTransitExampleProject.Common;
using MassTransitExampleProject.MessageContracts;
using System;

namespace MassTransitExampleProject.OrderStatusService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "OrderService";


            var bus = BusConfigurator
                .ConfigureBus((cfg) =>
                {
                    cfg.ReceiveEndpoint(RabbitMqConsts.OrderStatusServiceQueue, e =>
                    {
                        e.Consumer<UpdateOrderStatusCommandConsumer>();
                        e.UseCircuitBreaker(cb =>
                        {
                            cb.TrackingPeriod = TimeSpan.FromMinutes(1);     //reset interval süresinden(5dk) sonra 1 dk bekle bu sürede yine hata alınırsa diğer kuralları beklemeden yine 5dk bekle
                            cb.TripThreshold = 15;                          //alınan taleplerin yüzde 15 inde 5 dk bekle
                            cb.ActiveThreshold = 10;                       //10 hata alındığında 5 dk bekle
                            cb.ResetInterval = TimeSpan.FromMinutes(5);   //5 dk bekletir
                        });
                    });
                });

            bus.Start();

            Console.WriteLine("Listening order status command..");
            Console.ReadLine();
        }
    }
}
