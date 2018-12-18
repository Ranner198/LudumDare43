using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Leaderboard : MonoBehaviour {

    public Text leaderboardText;
    public GameObject loadSprite;
    private string textOutput;
    private float timer = 999999;

    // Reference to the dreamloLeaderboard prefab in the scene
    dreamloLeaderBoard dl;

    void Start()
    {
        this.dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();
        dl.LoadScores();
    }

    public void UpdateScores()
    {

        loadSprite.SetActive(true);

        dl.LoadScores();

        leaderboardText.text = "Loading.....";

        StartCoroutine(DisplayScores());
        StopCoroutine(DisplayScores());
    }

    IEnumerator DisplayScores()
    {
        yield return new WaitForSeconds(3);
        loadSprite.SetActive(false);
        textOutput = "";

        List<dreamloLeaderBoard.Score> scoreList = dl.SecondsLowToHigh();

        //Make sure to make this a Scroll feature --------
        int maxToDisplay = 20;
        int count = 0;

        foreach (dreamloLeaderBoard.Score currentScore in scoreList)
        {
            count++;
            if (currentScore.playerName == PlayerPrefs.GetString("name"))
            {
                textOutput += "<color=red>" + "Name:  " + currentScore.playerName + " :  ";
                float holder = currentScore.seconds;
                var temp = GenerateTime(holder);
                textOutput += temp + "s" + "</color>" + "\n";
                print(true);
            }
            else
            {
                textOutput += "Name:  " + currentScore.playerName + " :  ";
                float holder = currentScore.seconds;
                var temp = GenerateTime(holder);
                textOutput += temp + "s\n";
            }
                if (count >= maxToDisplay) break;            
        }
        leaderboardText.text = "-SpeedRun Leaderboard-\n" + textOutput;
    }

    public void UploadScore(float time)
    {
        timer = time;
        ValidateScores();
    }

    void ValidateScores()
    {
        List<dreamloLeaderBoard.Score> scoreList = dl.SecondsLowToHigh();

        int count = 0;

        foreach (dreamloLeaderBoard.Score currentScore in scoreList)
        {
            count++;
            if (currentScore.playerName == PlayerPrefs.GetString("name"))
            {
                if (Mathf.RoundToInt(timer * 100) < currentScore.seconds)
                {
                    dl.AddScore(PlayerPrefs.GetString("name"), 1, Mathf.RoundToInt(timer*100));
                    print("ScoreUpdated");
                }
                return;
            }
            if (count >= scoreList.Count)
            {
                print("Score Posted......");
                dl.AddScore(PlayerPrefs.GetString("name"), 1, Mathf.RoundToInt(timer * 100));
            }
        }
    }

    string GenerateTime(float temp)
    {
        float val = temp * .01f;

        int min = 0;
        float seconds = 0.0f;

        while (val > 60)
        {
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

    public bool ValidateScore() {

        return true;
    }



    public void PullScore () {
        dl.LoadScores();
    }
}
