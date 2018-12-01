using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    private Vector3 movement = Vector3.zero;
    private Vector3 dir;
    private Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}

	void Update () {

        movement = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));

        if (movement.magnitude > .1f)
        {
            rb.AddForce(transform.forward * speed);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-movement), Time.deltaTime * 2);
        }
	}
}
