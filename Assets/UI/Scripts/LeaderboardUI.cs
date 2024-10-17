using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class LeaderboardUI : MonoBehaviour {
    public static LeaderboardUI Instance { get; private set; }

    [SerializeField] private GameObject loadingGameObject;

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;
    private void Awake() {
        Instance = this;

        //GetComponent<RectTransform>().anchoredPosition = Vector2.zero; // Reset Position
        //GetComponent<RectTransform>().sizeDelta = Vector2.zero; // Reset Size

        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        Hide();
    }
    public void Hide() {
        gameObject.SetActive(false);
    }
    public void Show() {
        gameObject.SetActive(true);
        transform.SetAsLastSibling();
    }
    public void ShowLoading() {
        gameObject.SetActive(true);
        loadingGameObject.SetActive(true);
    }
    private void CreateHighscoreEntryTransform(LeaderboardSingle leaderboardSingle, Transform container, List<Transform> transformList) {
        float templateHeight = 31f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank) {
        default:
            rankString = rank + "TH"; break;
        case 1: rankString = "1ST"; break;
        case 2: rankString = "2ND"; break;
        case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;

        float score = leaderboardSingle.score;

        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = leaderboardSingle.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;
      

        // Set background visible odds and evens, easier to read
        //entryTransform.Find("background").gameObject.SetActive(rank % 2 == 1);

        // Highlight First
        if (rank == 1 || rank == 2 || rank == 3) {
            entryTransform.Find("posText").GetComponent<Text>().color = Color.magenta;
            entryTransform.Find("scoreText").GetComponent<Text>().color = Color.magenta;
            entryTransform.Find("nameText").GetComponent<Text>().color = Color.magenta;
        }
        // Set trophy
        switch (rank)
            {
                default:
                    entryTransform.Find("trophy").gameObject.SetActive(false);
                    break;
                case 1:
                    entryTransform.Find("trophy").GetComponent<Image>().color = Color.black;
                    break;
                case 2:
                    entryTransform.Find("trophy").GetComponent<Image>().color = Color.yellow;
                    break;
                case 3:
                    entryTransform.Find("trophy").GetComponent<Image>().color = Color.gray;
                    break;
                case 4:
                    entryTransform.Find("trophy").GetComponent<Image>().color = Color.blue;
                    break;
                case 5:
                    entryTransform.Find("trophy").GetComponent<Image>().color = Color.blue;
                    break;
                case 6:
                    entryTransform.Find("trophy").GetComponent<Image>().color = Color.blue;
                    break;
                case 7:
                    entryTransform.Find("trophy").GetComponent<Image>().color = Color.blue;
                    break;
                case 8:
                    entryTransform.Find("trophy").GetComponent<Image>().color = Color.blue;
                    break;
                case 9:
                    entryTransform.Find("trophy").GetComponent<Image>().color = Color.blue;
                    break;
                case 10:
                    entryTransform.Find("trophy").GetComponent<Image>().color = Color.blue;
                    break;
            }
        transformList.Add(entryTransform);
    }
    public void ShowLeaderboard(Leaderboard leaderboard) {
        gameObject.SetActive(true);
        loadingGameObject.SetActive(false);

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
        highscoreEntryTransformList = new List<Transform>();
        foreach (LeaderboardSingle leaderboardSingle in leaderboard.leaderboardSingleList) {
            CreateHighscoreEntryTransform(leaderboardSingle, entryContainer, highscoreEntryTransformList);
        }
        

    }
}
