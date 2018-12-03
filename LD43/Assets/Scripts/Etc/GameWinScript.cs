using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameWinScript : MonoBehaviour {

    public static bool hasWon = false;

    public GameObject GameSpace;
    public GameObject WinPanel;
    public Text numLeft;
    public Text finishTime;

    public Leaderboard leaderboard;

    public float Timer = 0;

    private bool upload = false;

    private void Start()
    {
        hasWon = false;
    }

    void Update() {

        var num = GameObject.FindGameObjectsWithTag("TriggerZone").Length;

        if (num == 0)
        {
            print("Game Over you won!");
            hasWon = true;
        }

        numLeft.text = "Houses Left:\n" + num;

        if (hasWon)
        {
            string Output = GenerateTime(Timer);
            Cursor.visible = true;
            GameSpace.SetActive(false);
            WinPanel.SetActive(true);
            finishTime.text = "Total Time:\n" + Output;
            if (!upload)
            {
                upload = true;
                leaderboard.UploadScore(Timer);                
            }
        } else {
            Timer += Time.deltaTime;        
        }
	}

    string GenerateTime(float val)
    {
        int min = 0;
        float seconds = 0.0f;

        while (val > 60)
        {
            print(true);
            min++;
            val -= 60;
        }

        seconds = val;

        if (seconds < 10)
        {
            var temp = seconds;
            seconds = '0' + temp;
        }

        return min.ToString() + ":" + seconds.ToString("F2");
    }
}
