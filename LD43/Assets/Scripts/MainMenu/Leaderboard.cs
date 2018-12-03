using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Leaderboard : MonoBehaviour {

    public Text leaderboardText;
    public GameObject loadSprite;
    private string textOutput;

    // Reference to the dreamloLeaderboard prefab in the scene

    dreamloLeaderBoard dl;

    void Start()
    {
        this.dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();
    }

    public void UploadScore(float time)
    {
        string name = PlayerPrefs.GetString("name");
        int holder = Mathf.RoundToInt(time * 100);
        print(holder);
        dl.AddScore(name, 1, holder);
        print("ScoreUpdated");
    }

    IEnumerator displayScores()
    {
        yield return new WaitForSeconds(3);
        loadSprite.SetActive(false);
        textOutput = "";

        List<dreamloLeaderBoard.Score> scoreList = dl.ToListHighToLow();

        int maxToDisplay = 5;
        int count = 0;

        foreach (dreamloLeaderBoard.Score currentScore in scoreList)
        {
            print(currentScore);
            count++;
            textOutput += "Name:  " + currentScore.playerName + " :  ";
            float holder = currentScore.seconds;
            var temp = GenerateTime(holder);
            textOutput += temp + "s\n";
            if (count >= maxToDisplay) break;
        }
        leaderboardText.text = "-SpeedRun Leaderboard-\n" + textOutput;
    }

    public void UpdateScores() {

        loadSprite.SetActive(true);

        dl.LoadScores();

        leaderboardText.text = "Loading.....";

        StartCoroutine(displayScores());
        StopCoroutine(displayScores());
    }

    string GenerateTime(float temp)
    {
        float val = temp * .01f;

        int min = 0;
        float seconds = 0.0f;

        while (val > 60)
        {
            print(true);
            min++;
            val -= 60;
        }

        seconds = val;

        string sec = "";

        if (seconds < 10)
        {
            sec = '0' + seconds.ToString("F2");
        } else
            sec = seconds.ToString("F2");

        return min.ToString() + ":" + sec;
    }
}
