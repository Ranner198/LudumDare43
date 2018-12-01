using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceEffect : MonoBehaviour {

    public float amount = 1;
    private float height = 0;

    private void Start()
    {
        height = transform.position.y;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, height + Mathf.Sin(Time.time) * amount, transform.position.z);
    }
}
