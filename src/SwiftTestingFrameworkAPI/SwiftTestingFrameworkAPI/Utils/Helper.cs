﻿using System;
using System.Diagnostics;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace SwiftTestingFrameworkAPI.Utils
{
    public class Helper
    {
        public class ProcessOutput 
        {
            public int ExitCode { get; set; }
            public string ErrorMessage { get; set; }

            public ProcessOutput(int exitCode, string errorMessage)
            {
                ExitCode = exitCode;
                ErrorMessage = errorMessage;
            }
        }

        public static ProcessOutput StartProcess(string exe, string arguments)
        {
            Process p = new Process();
            p.StartInfo.FileName = exe;
            p.StartInfo.Arguments = arguments;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            string err = p.StandardError.ReadToEnd();
            p.WaitForExit();
            return new ProcessOutput(p.ExitCode, err);
        }

        public static PageBlobClient GetPageBlobClient(string blobName)
        {
            string connectionStringName = Constants.ConnectionStringVariablePrefix + Constants.StorageConnectionStringName;
            string connectionString = Environment.GetEnvironmentVariable(connectionStringName) ?? string.Empty;

            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(Constants.StorageContainerName);
            containerClient.CreateIfNotExists();

            PageBlobClient pageBlobClient = containerClient.GetPageBlobClient(blobName);
            return pageBlobClient;
        }
    }
}
