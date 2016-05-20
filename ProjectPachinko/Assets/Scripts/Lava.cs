using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour {

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<BallStatus>().die();
        }
    }
}
