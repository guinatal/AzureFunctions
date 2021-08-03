# Azure Functions

A C# project with multiple `azure functions` triggers examples.

- Visual Studio 2022 Preview
- Framework .NET Core 3.1

## Projects / Functions

- Blob Trigger
- `In Progress` Service Bus trigger
- `TODO` Http trigger
- `TODO` Timer trigger
- `TODO` Queue trigger
- `TODO` Cosmos DB trigger

## 1 - Blob Trigger

The **NewDocument** function is triggered when a new file is dropped into the blob container.

### Setup

Create **local.settings.json**

```json
{
    "IsEncrypted": false,
    "Values": {
        "AzureWebJobsStorage": "DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey={AccountKey};BlobEndpoint={BlobEndpoint};TableEndpoint={TableEndpoint};QueueEndpoint={QueueEndpoint};FileEndpoint={FileEndpoint}",
        "FUNCTIONS_WORKER_RUNTIME": "dotnet"
}
```

### Run the project

Compile and run: If using Visual Studio, just press F5 to compile and run **AzureFunctionTriggerBlobStorage**

## 2 - Service Bus trigger

- PDFHandlerFunction
- CSVHandlerFunction
- NAHandlerFunction

`In Progress`

## Contribute
Contributions are welcome.
