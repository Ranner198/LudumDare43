using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShowMobleKeyboard : MonoBehaviour {

    public bool keyboardVisibilty = false;
    private TouchScreenKeyboard keyboard;

    public void Update()
    {
        if (keyboard != null && keyboard.status == TouchScreenKeyboard.Status.Done)
            Hide();        
    }

    public void ShowKeyboard()
    {
        keyboardVisibilty = true;
        if (keyboard == null)
            keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, true, false, false, true);
    }

    public void Hide() 
    {
        keyboard.active = false;
        keyboardVisibilty = false;
    }
}
