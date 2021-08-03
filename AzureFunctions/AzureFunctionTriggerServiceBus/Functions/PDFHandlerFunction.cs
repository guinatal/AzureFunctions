using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFunctionTriggerServiceBus.Functions
{
    public static class PDFHandlerFunction
    {
        [FunctionName("PDF-Handler")]
        public static void Run([ServiceBusTrigger("myfirstservicebustopic", "handler-pdf-subscription")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
