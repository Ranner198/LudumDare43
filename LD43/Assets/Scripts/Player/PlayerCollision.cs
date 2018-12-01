using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public static int RedBoxes = 0;
    public static int GreenBoxes = 0;
    public static int BlueBoxes = 0;

    public GameObject[] prefabs;

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

        if (coll.tag == "TriggerZone")
        {
            if (coll.name == "Red")
            {
                if (RedBoxes > 0)
                {
                    RedBoxes--;
                    GameObject redBox = Instantiate(prefabs[0], transform.position, Quaternion.identity);
                    redBox.name = "Red Box Prefab";
                    Destroy(coll.gameObject);
                }
            }
            if (coll.name == "Green")
            {
                if (GreenBoxes > 0)
                {
                    GreenBoxes--;
                    GameObject greenBox = Instantiate(prefabs[1], transform.position, Quaternion.identity);
                    greenBox.name = "Green Box Prefab";
                    Destroy(coll.gameObject);
                }
            }
            if (coll.name == "Blue")
            {
                if (BlueBoxes > 0)
                {
                    BlueBoxes--;
                    GameObject blueBox = Instantiate(prefabs[2], transform.position, Quaternion.identity);
                    blueBox.name = "Blue Box Prefab";
                    Destroy(coll.gameObject);
                }
            }
        }
    }

}
