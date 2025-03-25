using Ecommerce.MessageBus;

namespace Ecommerce.Services.CartAPI.RabbitMQSender
{
    public interface IRabbitMQCartMessageSender
    {
        void SendMessage(BaseMessage baseMessage, String queueName);
    }
}
