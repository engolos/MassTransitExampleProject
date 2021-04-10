using System;

namespace MassTransitExampleProject.MessageContracts
{
    public interface IUpdateOrderStatusCommand //Talebi kaydetmek için statü güncellemesi yapılması istendiğinde kullanılır.
    {
        Guid OrderId { get; set; }
        string OrderStatus { get; set; }
    }
}
