using System;
using MassTransit;
using MassTransit.RabbitMqTransport;
using GreenPipes;
using MassTransitExampleProject.MessageContracts;

namespace MassTransitExampleProject.Common
{
    public static class BusConfigurator //Bus’ı yönetmek için
    {
        public static IBusControl ConfigureBus(Action<IRabbitMqBusFactoryConfigurator> registrationAction = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>       //RabbitMQ sunucusuna bağlanabilmek için
            {
                cfg.Host(new Uri(RabbitMqConsts.RabbitMqUri), hst =>
                {
                    hst.Username(RabbitMqConsts.UserName);
                    hst.Password(RabbitMqConsts.Password);
                });

                registrationAction?.Invoke(cfg);
            });
        }
    }
}
