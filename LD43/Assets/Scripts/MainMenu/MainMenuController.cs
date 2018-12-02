using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

    public GameObject MainMenu;
    public GameObject Settings;
    public GameObject Credits;

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
