using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderBoardUI : Singleton<LeaderBoardUI>
{
    [SerializeField] GameObject playerScorePrefab;

    List<LeaderboardData> myLeaderboards = new List<LeaderboardData>();

    public List<LeaderboardData> MyLeaderboards { get => myLeaderboards; set => myLeaderboards = value; }

    protected override void Awake()
    {

    }

    private void Start()
    {
        SetLeaderboard();
    }

    public void SetLeaderboard()
    {
        foreach (LeaderboardData leaderboardData in myLeaderboards)
        {
            GameObject prefabInstance = Instantiate(playerScorePrefab, transform);
            prefabInstance.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = leaderboardData.PlayerUsername;
            prefabInstance.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = leaderboardData.PlayerScore.ToString();
        }
    }

    public void closeLeaderboar()
    {
        gameObject.SetActive(false);
    }
}