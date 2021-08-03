using System;
using static AzureFunctionShared.Enums;

namespace AzureFunctionShared
{
    public class Document
    {
        public Document(string fileName, string fileNameOriginal, DateTime receivedDate, DocumentType type)
        {
            this.FileName = fileName;
            this.FileNameOriginal = fileNameOriginal;
            this.ReceivedDate = receivedDate;
            this.Type = type;
        }

        public string? FileName { get; set; }
        public string? FileNameOriginal { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DocumentType Type { get; set; }
    }
}