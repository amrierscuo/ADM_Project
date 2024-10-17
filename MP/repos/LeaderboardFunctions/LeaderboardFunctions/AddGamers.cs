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
    public static class AddGamers
    {
        /*[FunctionName("AddGamers")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [Blob("leaderboardcontainer/testHF.json", FileAccess.Read, Connection = "AzureWebJobsStorage")] string testHFBlobString,
            [Blob("leaderboardcontainer/testHF.json", FileAccess.Write, Connection = "AzureWebJobsStorage")] TextWriter testHFBlobTextWriter,
            ILogger log)
        {
            log.LogInformation("AddGamers");
            //Leaderboard->gamers!
            Leaderboard leaderboard = JsonConvert.DeserializeObject<Leaderboard>(testHFBlobString);

            string requestBody = new StreamReader(req.Body).ReadToEnd();

            LeaderboardSingle leaderboardSingle = JsonConvert.DeserializeObject<LeaderboardSingle>(requestBody);

            leaderboard.leaderboardSingleList.Add(leaderboardSingle);
            
            string saveBlobData = JsonConvert.SerializeObject(leaderboard);
            testHFBlobTextWriter.Write(saveBlobData);//do not let the fill be empty
            return new OkObjectResult(saveBlobData);
        }*/
    }
}
