using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShowPresentImages : MonoBehaviour {

    public Image[] red;
    public Image[] green;
    public Image[] blue;

    void Update () {
        for (int i = 0; i < red.Length; i++)
        {
            if(i < PlayerCollision.RedBoxes)
                red[i].enabled = true;
            else
                red[i].enabled = false;
        }
        for (int i = 0; i < green.Length; i++)
        {
            if (i < PlayerCollision.GreenBoxes)
                green[i].enabled = true;
            else
                green[i].enabled = false;
        }
        for (int i = 0; i < blue.Length; i++)
        {
            if (i < PlayerCollision.BlueBoxes)
                blue[i].enabled = true;
            else
                blue[i].enabled = false;
        }
    }
}
