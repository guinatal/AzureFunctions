using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFunctionTriggerBlogStorage
{
    public static class BlobStorageFunction
    {
        [FunctionName("BlobStorageFunction")]
        public static void Run([BlobTrigger("azure-function-test-container/{name}", Connection = "")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

            // todo: send a message through service bus from here

        }
    }
}
