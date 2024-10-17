/*using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class AchievementSystemUI : MonoBehaviour {
    public static AchievementSystemUI Instance { get; private set; }

    [SerializeField] private GameObject loadingGameObject;

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> achievementSystemEntryTransformList;
    private void Awake() {
        Instance = this;
    }
    
    public void ShowLeaderboard(Leaderboard leaderboard) {
        string name = leaderboardSingle.name;
        // Sort entry list by Score
        for (int i = 0; i < leaderboard.leaderboardSingleList.Count; i++) {
            for (int j = i + 1; j < leaderboard.leaderboardSingleList.Count; j++) {
                if (leaderboard.leaderboardSingleList[j].score > leaderboard.leaderboardSingleList[i].score) {
                    // Swap
                    LeaderboardSingle tmp = leaderboard.leaderboardSingleList[i];
                    leaderboard.leaderboardSingleList[i] = leaderboard.leaderboardSingleList[j];
                    leaderboard.leaderboardSingleList[j] = tmp;
                }
            }
        }
    }
  }
}
*/