using SampleShared;

namespace SampleWebSender.Services
{
    public interface IAzureBusService
    {
         Task SendMessageAsync(Person personMesaage, string queueName);
    }
}