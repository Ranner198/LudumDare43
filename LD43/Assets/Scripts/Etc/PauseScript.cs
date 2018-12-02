using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseScript : MonoBehaviour {

    public GameObject PauseMenu;
    public MainMenuController fader;

    private bool paused;

    void Start() {
        Time.timeScale = 1;
    }

	void Update () {
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
            PauseMenu.SetActive(true);
            Cursor.visible = true;
        } else {
            PauseMenu.SetActive(false);
            Cursor.visible = false;
        }
	}

    public void Resume() {
        paused = false;
        Time.timeScale = 1;
    }

    void Paused() {
        Time.timeScale = 0;
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
        SceneManager.LoadScene("MainMenu");
    }
}
