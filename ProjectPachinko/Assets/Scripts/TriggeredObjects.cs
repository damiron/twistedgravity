using UnityEngine;
using System.Collections;

public class TriggeredObjects : MonoBehaviour {
	public Collider2D triggerCol;
	public Collider2D normalCol;
	public Renderer rend;
	void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player" && !col.GetComponent<BallStatus>().levelFinished)
        {            
            normalCol.enabled = true;
			rend.enabled = true;
			triggerCol.enabled = false;            
        }
    }
}
