using UnityEngine;
using System.Collections;

public class ForcedGravityUp : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            BallStatus bs = col.GetComponent<BallStatus>();
            bs.isOnAntiGravityY = true;
            bs.fixedGravityY = 11;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            BallStatus bs = col.GetComponent<BallStatus>();
            bs.isOnAntiGravityY = false;
            bs.fixedGravityY = 0;
        }
    }
}
