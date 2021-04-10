using MassTransitExampleProject.MessageContracts;
using System;

namespace MassTransitExampleProject.Api.Models
{
    public class OrderStatusModel : IUpdateOrderStatusCommand
    {
        public Guid OrderId { get; set; }
        public string OrderStatus { get; set; }
    }
}