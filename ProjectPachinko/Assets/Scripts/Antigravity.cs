using UnityEngine;
using System.Collections;

public class Antigravity : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<BallStatus>().isOnAntiGravity = true;
            Physics2D.gravity = Vector2.zero;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<BallStatus>().isOnAntiGravity = false;
        }
    }
}
