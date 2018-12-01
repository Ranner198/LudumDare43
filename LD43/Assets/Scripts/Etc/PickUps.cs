using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour {

    public float amount = 1;
    public float height = 0;
    public float offset = 0;

	void Update () {
        transform.position = new Vector3(transform.position.x, height + Mathf.Sin((offset + Time.time) * amount), transform.position.z);
	}
}
