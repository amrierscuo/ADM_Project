using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using UnityEngine.SocialPlatforms.Impl;
using System.Linq;

public class TestL : MonoBehaviour {
      private void Update() {
        if (Input.GetKeyDown(KeyCode.R))
        {
            LeaderboardSingle leaderboardSingle = new LeaderboardSingle
            {
                name = "player u",
                score = 5
            };

            WebRequests.PutJson("https://achievementleaderboard.azurewebsites.net/api/PutScore?code=zOr3dwn8MIR7OBCuUQWDYilR_ddqh65s6MKEXgz_gLT6AzFu557FwP==",
                JsonConvert.SerializeObject(leaderboardSingle),
                (string error) => {
                    Debug.Log("Error: " + error);
                },
                (string response) => {
                    Debug.Log("Response: " + response);

                    Leaderboard leaderboard = JsonConvert.DeserializeObject<Leaderboard>(response);
                    foreach (var item in leaderboard.leaderboardSingleList.Where(x => x.name == "player t"))
                    {
                        item.name = "player z";
                        Debug.Log(item.name + " " + item.score);

                    }

                    LeaderboardUI.Instance.ShowLeaderboard(leaderboard);
                });
        }

        if (Input.GetKeyDown(KeyCode.T)) {
            WebRequests.Get("https://achievementleaderboard.azurewebsites.net/api/GetLeaderboard?code=AUNQ4RYIkTrhcNBmO4jGy5SmsnJfEbrBPREtEgUbc4DPAzFuVyRwjA==",
                (string error) => {
                    Debug.Log("Error: " + error);
                },
                (string response) => {
                    Debug.Log("Response: " + response);

                    Leaderboard leaderboard = JsonConvert.DeserializeObject<Leaderboard>(response);
                    //Debug.Log(leaderboard.leaderboardSingleList[1].name); //Leaderboard
                    //Debug.Log(leaderboard.leaderboardSingleList); //System.Collections.Generic.List`1[LeaderboardSingle]
                    LeaderboardUI.Instance.ShowLeaderboard(leaderboard);
                });

        }
        if (Input.GetKeyDown(KeyCode.Y)) {
            LeaderboardSingle leaderboardSingle = new LeaderboardSingle {
                name = "player t",
                score = 1
            };
            WebRequests.PostJson("https://achievementleaderboard.azurewebsites.net/api/AddScore?code=B-SZPFlQaG13FMdvxYwdnmufTLzhgqnOXzZti71_bf87AzFu1YC9yw==",
                JsonConvert.SerializeObject(leaderboardSingle),
                (string error) => {
                    Debug.Log("Error: " + error);
                },
                (string response) => {
                    Debug.Log("Response: " + response);

                    
                    Leaderboard leaderboard = JsonConvert.DeserializeObject<Leaderboard>(response);
                
                    LeaderboardUI.Instance.ShowLeaderboard(leaderboard);

                });
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            WebRequests.Get("https://achievementleaderboard.azurewebsites.net/api/GetGamers?code=3Ee0PcspAvH_FzfKL5OYNz_KF5AjquF2vemRPWkW4BwjAzFuHeGeQX==",
                (string error) => {
                    Debug.Log("Error: " + error);
                },
            (string response) => {
                Gamers gamers = JsonConvert.DeserializeObject<Gamers>(response);
                GP games = JsonConvert.DeserializeObject<GP>(response);
                Debug.Log("Response-json: " + response);
                //Debug.Log("==class== :"+ gamers); //Gamers0
                //Debug.Log("==gamerSingleList== :"+ gamers.gamerSingleList); //System.Collections.Generic.List`1[GamerSingle0]
                //Debug.Log("name :" + gamers.gamerSingleList[1].name);
                //Debug.Log("TotAU :" + gamers.gamerSingleList[0].TotAU)
            });
            WebRequests.Get("https://achievementleaderboard.azurewebsites.net/api/GetGames?code=NBa-CrEBox2Ueu-nSQwUHW7PiBxnO8B-J7Hkw1Ofeff7AzFuL-Vmgw==",
            (string error) => {
                Debug.Log("Error: " + error);},
            (string response) => {
               GP games = JsonConvert.DeserializeObject<GP>(response);
                Debug.Log("Response-jsonGP: " + response);
                //Debug.Log("nameGame:" + games.gamesPlayedList[0].nameGame);
                //Debug.Log("gameScoreD:" + games.gamesPlayedList[0].gameScoreD);
                //Debug.Log("gameScoreR:" + games.gamesPlayedList[0].gameScoreR);
                //Debug.Log("numberAU:" + games.gamesPlayedList[0].numberAU);
                //Debug.Log("gameRateo:" + games.gamesPlayedList[0].gameRateo);
                //Debug.Log("AOPTPTG:" + games.gamesPlayedList[0].AOPTPTG);
            });
            WebRequests.Get("https://achievementleaderboard.azurewebsites.net/api/GetAchievements?code=IRp-oZgFMABmIKrs05JP4ftO8AFxBhCytzaRxXUOXNFnAzFu5IkFwQ==",
            (string error) => {
                Debug.Log("Error: " + error);},
            (string response) => {
             AU achievements = JsonConvert.DeserializeObject<AU>(response);
                Debug.Log("Response-jsonAU: " + response);
                Debug.Log("id0:" + achievements.achievementUnlockedList[0].id0);
                Debug.Log("timestamp0:" + achievements.achievementUnlockedList[0].timestamp0);
                Debug.Log("scoreD0:" + achievements.achievementUnlockedList[0].scoreD0);
                Debug.Log("scoreR0:" + achievements.achievementUnlockedList[0].scoreR0);
                Debug.Log("achRateo0:" + achievements.achievementUnlockedList[0].achRateo0);
                Debug.Log("flag0:" + achievements.achievementUnlockedList[0].flag0);
                Debug.Log("AOPTUTA0:" + achievements.achievementUnlockedList[0].AOPTUTA0);
                });
        }
    }
}
