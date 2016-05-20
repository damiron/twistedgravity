using UnityEngine;
using System.Collections;

public class PortalScript : MonoBehaviour {
    private bool soundStarted = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	/*void Update () {
	
	}*/

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (!soundStarted)
            {
                GameObject.FindObjectOfType<SoundEffectsHelper>().PlayVictory();
                soundStarted = true;
            }
            col.GetComponent<BallStatus>().levelFinished = true;
            col.GetComponent<Rigidbody2D>().isKinematic = true;            
        }
    }
}
