using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinScript : MonoBehaviour {

	void LateUpdate () {
        if (GameObject.FindGameObjectsWithTag("TriggerZone").Length == 0)
            print("Game Over you won!");
	}
}
