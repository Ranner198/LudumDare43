using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimerScript : MonoBehaviour {

    public Slider timer;
    public Image fillColor;

    //Gradient
    public Color startColor = Color.green, finishColor = Color.red;

	void LateUpdate () {

        fillColor.color = Color.Lerp(startColor, finishColor, timer.value/timer.maxValue);

        if (!GameWinScript.hasWon)
        {
            //Count Seconds
            timer.value -= Time.deltaTime / 2;

            //Handel Lost Condition
            if (timer.value < 0)
            {
                //Throw lose screen
                print("You have lost...");
            }
        }
	}
}
