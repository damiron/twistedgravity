using UnityEngine;
using System.Collections;

public class ForcedGravityLeft : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            BallStatus bs = col.GetComponent<BallStatus>();
            bs.isOnAntiGravityX = true;
            bs.fixedGravityX = -11;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            BallStatus bs = col.GetComponent<BallStatus>();
            bs.isOnAntiGravityX = false;
            bs.fixedGravityX = 0;
        }
    }
}
