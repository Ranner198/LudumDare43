using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float IphoneModifer = 4;

    private Vector3 movement = Vector3.zero;
    private Vector3 dir;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

#if UNITY_STANDALONE_WIN
        movement = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));

        if (movement.magnitude > .1f)
        {
            rb.AddForce(transform.forward * speed * Time.deltaTime * 60);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-movement), Time.deltaTime * 2);
        }
#endif
#if UNITY_EDITOR
        movement = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));

        if (movement.magnitude > .1f)
        {
            rb.AddForce(transform.forward * speed * Time.deltaTime * 60);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-movement), Time.deltaTime * 2);
        }
#endif
#if UNITY_IOS
        movement = new Vector3 (TouchScreenInput.dir.x, 0, TouchScreenInput.dir.y);

        if (movement.magnitude > .1f)
        {
            rb.velocity = transform.forward * speed * Time.deltaTime * 12;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(-movement), Time.deltaTime * IphoneModifer);
        }
#endif 
    }
}
