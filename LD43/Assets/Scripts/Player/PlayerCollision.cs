using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public static int RedBoxes = 0;
    public static int GreenBoxes = 0;
    public static int BlueBoxes = 0;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Pickup")
        {
            if (coll.name == "RedPresent")
            {
                RedBoxes++;
                Destroy(coll.gameObject);
            }
            if (coll.name == "GreenPresent")
            {
                GreenBoxes++;
                Destroy(coll.gameObject);
            }
            if (coll.name == "BluePresent")
            {
                BlueBoxes++;
                Destroy(coll.gameObject);
            }
        }
    }

}
