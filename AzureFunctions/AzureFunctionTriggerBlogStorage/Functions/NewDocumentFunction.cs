using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using AzureFunctionShared;
using AzureFunctionTriggerBlobStorage.Services;
using Microsoft.AspNetCore.Routing;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using static AzureFunctionShared.Enums;

namespace AzureFunctionTriggerBlobStorage.Functions
{
    public static class NewDocumentFunction
    {
        [FunctionName("NewDocument")]
        public static async Task RunAsync([BlobTrigger("azure-function-test-container/{name}", Connection = "")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

            // variables
            string fileName = Guid.NewGuid().ToString();
            DateTime receivedDate = DateTime.Now;
            DocumentType type;

            string extension = Path.GetExtension(name);
            if (String.Equals(extension, ".PDF", StringComparison.OrdinalIgnoreCase))
            {
                type = DocumentType.PDF;
            }
            else if (String.Equals(extension, ".CSV", StringComparison.OrdinalIgnoreCase))
            {
                type = DocumentType.CSV;
            }
            else
            {
                type = DocumentType.NA;
            }

            // create a document
            Document document = new Document(name, fileName, receivedDate, type);

            // serialize it
            string message = JsonSerializer.Serialize(document);

            // send to bus service
            BusSenderService busSenderService = new BusSenderService();
            await busSenderService.Send(message, type);
        }
    }
}