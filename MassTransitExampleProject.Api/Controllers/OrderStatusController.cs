using MassTransit;
using MassTransitExampleProject.Api.Models;
using MassTransitExampleProject.Common;
using MassTransitExampleProject.MessageContracts;
using System;
using System.Web.Http;

namespace MassTransitExampleProject.Api.Controllers
{
    public class OrderStatusController : ApiController
    {
        private readonly ISendEndpoint _bus;

        public OrderStatusController()
        {
            var busControl = BusConfigurator.ConfigureBus();
            var sendToUri = new Uri($"{RabbitMqConsts.RabbitMqUri}{RabbitMqConsts.OrderStatusServiceQueue}");

            _bus = busControl.GetSendEndpoint(sendToUri).Result;
        }

        // POST api/order
        [HttpPost]
        public IHttpActionResult Post(Guid orderId, string orderStatus)
        {
            var orderStatusModel = new OrderStatusModel
            {
                OrderId = orderId,
                OrderStatus = orderStatus
            };
            UpdateOrder(orderStatusModel);
            return Ok("Sipariş statüsü alındı... OrderId : " + orderId + "  OrderStatus : " + orderStatus);
        }

        private void UpdateOrder(OrderStatusModel orderStatusModel)
        {
            _bus.Send(orderStatusModel).Wait();
        }
    }
}
