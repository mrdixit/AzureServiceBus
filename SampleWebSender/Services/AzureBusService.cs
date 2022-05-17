using System.Text;
using System.Text.Json;
using Microsoft.Azure.ServiceBus;
using SampleShared;

namespace SampleWebSender.Services
{
    public class AzureBusService : IAzureBusService
    {
        private readonly IConfiguration _configuration;

        public AzureBusService(IConfiguration config)
        {
            this._configuration = config;
        }

        public async Task SendMessageAsync(Person personMesaage, string queueName)
        {
            var connectionString = _configuration.GetConnectionString("AzureServiceBusConnection");
            var qClient = new QueueClient(connectionString, queueName);

            var msgBody = JsonSerializer.Serialize(personMesaage);
            var msg = new Message(Encoding.UTF8.GetBytes(msgBody));

            await qClient.SendAsync(msg);
            
        }
    }
}