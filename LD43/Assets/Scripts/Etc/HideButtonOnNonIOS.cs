using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideButtonOnNonIOS : MonoBehaviour
{
    void Start()
    {
#if UNITY_IOS || UNITY_EDITOR
        this.enabled = true;
#else
        this.enabled = false;
#endif
    }
}
