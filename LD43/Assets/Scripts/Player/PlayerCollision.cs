using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public static int RedBoxes = 0;
    public static int GreenBoxes = 0;
    public static int BlueBoxes = 0;

    public GameObject[] prefabs;

    public AudioClip pickupSound, dropOffSound;

    public AudioSource _souce;

    public float offset = 0;    
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Pickup")
        {
            if (coll.name == "RedPresent")
            {
                RedBoxes++;
                Destroy(coll.gameObject);
                _souce.PlayOneShot(pickupSound);
            }
            if (coll.name == "GreenPresent")
            {
                GreenBoxes++;
                Destroy(coll.gameObject);
                _souce.PlayOneShot(pickupSound);
            }
            if (coll.name == "BluePresent")
            {
                BlueBoxes++;
                Destroy(coll.gameObject);
                _souce.PlayOneShot(pickupSound);
            }
        }

        if (coll.tag == "TriggerZone")
        {
            if (coll.name == "Red")
            {
                if (RedBoxes > 0)
                {
                    RedBoxes--;
                    Vector3 pos = transform.position;
                    pos.y += offset;
                    GameObject redBox = Instantiate(prefabs[0], pos, Quaternion.identity);
                    redBox.name = "Red Box Prefab";
                    Destroy(coll.gameObject);
                    _souce.PlayOneShot(dropOffSound);
                }
            }
            if (coll.name == "Green")
            {
                if (GreenBoxes > 0)
                {
                    GreenBoxes--;
                    Vector3 pos = transform.position;
                    pos.y += offset;
                    GameObject greenBox = Instantiate(prefabs[1], pos, Quaternion.identity);
                    greenBox.name = "Green Box Prefab";
                    Destroy(coll.gameObject);
                    _souce.PlayOneShot(dropOffSound);
                }
            }
            if (coll.name == "Blue")
            {
                if (BlueBoxes > 0)
                {
                    BlueBoxes--;
                    Vector3 pos = transform.position;
                    pos.y += offset;
                    GameObject blueBox = Instantiate(prefabs[2], pos, Quaternion.identity);
                    blueBox.name = "Blue Box Prefab";
                    Destroy(coll.gameObject);
                    _souce.PlayOneShot(dropOffSound);
                }
            }
        }
    }

}
