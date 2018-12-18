using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject Settings;
    public GameObject Leaderboard;
    public GameObject Controls;

    //For Leaderboard stuff
    public InputField inputFieldText;
    public Leaderboard lb;

    void Start()
    {
        Cursor.visible = true;
        if (inputFieldText != null)
            inputFieldText.text = PlayerPrefs.GetString("name");
        if (Settings != null)
            Settings.SetActive(false);
        if (Controls != null)
            Controls.SetActive(false);
    }

    public void PlayButton() {
        if (inputFieldText.text != "" && Regex.IsMatch(inputFieldText.text, @"[a-zA-Z0-9]"))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetString("name", inputFieldText.text);
            FadeOut(1);
        } else
        {
            var temp = inputFieldText.placeholder.GetComponent<Text>();
            temp.text = "<ENTER NAME>";
            temp.color = Color.red;
        }
    }

    public void SettingsButton() {
        MainMenu.SetActive(false);
        Settings.SetActive(true);
    }
    public void CreditsButton()
    {
        MainMenu.SetActive(false);
        Controls.SetActive(true);
    }

    public void Back() {
        Controls.SetActive(false);
        Settings.SetActive(false);
        Leaderboard.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void OpenLeaderboard() {
        Leaderboard.SetActive(true);
        MainMenu.SetActive(false);
        lb.UpdateScores();
    }


    //Fade Logic

    public Animator fader;
    private int levelIndex = 0;
    public void FadeOut(int val)
    {
        fader.SetTrigger("FadeOut");
        levelIndex = val;
    }
    public void OnAnimComplete()
    {
        SceneManager.LoadScene(levelIndex);
    }
}
