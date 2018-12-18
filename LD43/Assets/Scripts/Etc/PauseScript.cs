using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseScript : MonoBehaviour {

    public GameObject PauseMenu;
    public GameObject Settings;

    public Text Fps;
    private float FramesPerSecond;

    public MainMenuController fader;

    private bool paused = false, settings = false;

    void Start() {
        Time.timeScale = 1;
        Application.targetFrameRate = 60;
    }

	void Update () {        

        FramesPerSecond = Time.frameCount / Time.time;
        var avgFrameRate = (int)FramesPerSecond;
        Fps.text = avgFrameRate.ToString() + " FPS";

        if (!GameWinScript.hasWon)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (paused)
                {
                    paused = false;
                    Time.timeScale = 1;
                }
                else
                    paused = true;
            }
        }
        if (paused)
        {
            Paused();
            if(!settings)
                PauseMenu.SetActive(true);
            Cursor.visible = true;
        } else {
            PauseMenu.SetActive(false);
            if (!GameWinScript.hasWon)
                Cursor.visible = false;
        }
	}

    public void Resume() {
        paused = false;
        Time.timeScale = 1;
    }

    public void Paused() {
        Time.timeScale = 0;
        paused = true;
    }

    public void Restart() {
        paused = false;
        Time.timeScale = 1;
        fader.FadeOut(1);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void MainMenu() {
        paused = false;
        Time.timeScale = 1;        
        SceneManager.LoadScene("MainMenu");
    }

    public void SettingsButton() {
        settings = true;
        Settings.SetActive(true);
        PauseMenu.SetActive(false);
    }

    public void BackButton() {
        settings = false;
        Settings.SetActive(false);
        PauseMenu.SetActive(true);
    }
}
