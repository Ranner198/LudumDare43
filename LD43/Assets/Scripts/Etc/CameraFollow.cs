using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform player;
    public float distance;

	void LateUpdate () {
        transform.position = new Vector3(player.transform.position.x, -distance, player.transform.position.z + distance);
	}
}
