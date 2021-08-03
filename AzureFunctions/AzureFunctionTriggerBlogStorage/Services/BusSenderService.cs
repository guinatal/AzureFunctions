using Azure.Messaging.ServiceBus;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static AzureFunctionShared.Enums;

namespace AzureFunctionTriggerBlobStorage.Services
{
    public class BusSenderService
    {
        // connection string to your Service Bus namespace
        private readonly string connectionString = Environment.GetEnvironmentVariable("AzureWebJobsServiceBus");

        // name of your Service Bus topic
        private readonly string topicName = Environment.GetEnvironmentVariable("AzureWebJobsServiceBusTopicName");

        // the client that owns the connection and can be used to create senders and receivers
        private readonly ServiceBusClient client;

        // the sender used to publish messages to the topic
        private readonly ServiceBusSender sender;

        public BusSenderService()
        {
            client = new ServiceBusClient(connectionString);
            sender = client.CreateSender(topicName);
        }

        public async Task Send(string message, DocumentType type)
        {
            try
            {
                ServiceBusMessage busMessage = new ServiceBusMessage(message);

                busMessage.ApplicationProperties["documentType"] = Enum.GetName(typeof(DocumentType), type);

                // Use the producer client to send the message to the Service Bus topic
                await sender.SendMessageAsync(busMessage);
            }
            finally
            {
                // Calling DisposeAsync on client types is required to ensure that network
                // resources and other unmanaged objects are properly cleaned up.
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }
        }
    }
}
