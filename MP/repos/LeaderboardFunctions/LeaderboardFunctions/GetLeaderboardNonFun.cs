using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace LeaderboardFunctions
{
    public static class GetLeaderboardNonFun
    {
        [FunctionName("GetLeaderboardNonFun")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            log.LogInformation("C# HTTP trigger function processed a request.");

            string connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");

            string containerName = "leaderboardcontainer";
            
            BlobContainerClient blobContainerClient = new BlobContainerClient(connectionString, containerName);

            BlobClient blobClient = blobContainerClient.GetBlobClient("Leaderboard.json");

            string responseMessage = "";

            BlobDownloadInfo blobDownloadInfo = blobClient.Download();
            
            using (StreamReader streamReader = new StreamReader(blobDownloadInfo.Content))
            {
               responseMessage = streamReader.ReadToEnd();
            }
            return new OkObjectResult(responseMessage);
        }
    }
}
