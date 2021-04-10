namespace MassTransitExampleProject.MessageContracts
{
    public class RabbitMqConsts  //Rabbitmq erişim ve queue bilgilerini yönetmek için
    {
        public const string RabbitMqUri = "rabbitmq://localhost/orderstatus/";
        public const string UserName = "exampleuser";
        public const string Password = "user123";
        public const string OrderStatusServiceQueue = "orderevents.service";
        public const string SmsNotificationServiceQueue = "sms.notification.service";
        public const string MailNotificationServiceQueue = "mail.notification.service";
    }
}
