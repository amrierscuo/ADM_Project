using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;

namespace LeaderboardFunctions
{
    public static class PutScore
    {
        [FunctionName("PutScore")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "put", Route = null)] HttpRequest req,
            [Blob("leaderboardcontainer/Leaderboard.json", FileAccess.Read, Connection = "AzureWebJobsStorage")] string leaderboardBlobString,
            [Blob("leaderboardcontainer/Leaderboard.json", FileAccess.Write, Connection = "AzureWebJobsStorage")] TextWriter leaderboardBlobTextWriter,
            ILogger log)
        {
            log.LogInformation("name");

            Leaderboard leaderboard = JsonConvert.DeserializeObject<Leaderboard>(leaderboardBlobString);

            string requestBody = new StreamReader(req.Body).ReadToEnd();

            LeaderboardSingle leaderboardSingle = JsonConvert.DeserializeObject<LeaderboardSingle>(requestBody);

            //leaderboard.leaderboardSingleList.Add(leaderboardSingle);
            
            foreach (LeaderboardSingle leaderboardSingleItem in leaderboard.leaderboardSingleList)
            {
                leaderboardSingleItem.name = leaderboardSingle.name;
                leaderboardSingleItem.score = leaderboardSingle.score;
                
                leaderboardBlobTextWriter.Write(JsonConvert.SerializeObject(leaderboard));
                    return new OkObjectResult("Score updated");
            }
            string saveBlobData = JsonConvert.SerializeObject(leaderboard);
            leaderboardBlobTextWriter.Write(saveBlobData);//do not let the fill be empty
            return new OkObjectResult(saveBlobData);
        }
    }
}
