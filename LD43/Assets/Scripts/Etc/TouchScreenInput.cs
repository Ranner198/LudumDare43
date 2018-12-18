using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScreenInput : MonoBehaviour
{
    Vector3 firstTouch = Vector3.zero;
    Vector3 currentPos = Vector3.zero;

    public static Vector3 dir;

    public Camera mainCam;

    void Start() {
        dir = Vector3.zero;
    }

    void FixedUpdate()
    {

        if (Input.touches.Length > 0)
        {
            if (firstTouch == Vector3.zero)
                firstTouch = mainCam.ScreenToViewportPoint(Input.touches[0].position);

            currentPos = mainCam.ScreenToViewportPoint(Input.touches[0].position);

            dir = (firstTouch- currentPos).normalized;
            /*
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                firstTouch = Vector3.zero;
                currentPos = Vector3.zero;
            }
            */
        }
        else
        {
            firstTouch = Vector3.zero;
            currentPos = Vector3.zero;
        }
    }
}