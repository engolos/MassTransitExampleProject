using System;

namespace MassTransitExampleProject.MessageContracts
{
    public interface IOrderStatusChangedEvent          //Event --> Olay gerçekleşti, bilgilendirme (bildirim gönderme) işlemlerinde kullanılır.
    {
        Guid OrderId { get; set; }          //Kaydedilen talebi dinleyen consumer’ları bilgilendirmek için  
        string OrderStatus { get; set; }
        string OrderMessage { get; set; }
    }
}
