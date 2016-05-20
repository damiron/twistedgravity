using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;

public class OrangePortalScript : MonoBehaviour {
	public GameObject destination;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "Player")
		{
            
			GameObject.FindObjectOfType<SoundEffectsHelper>().PlayPortal();
            GameObject.FindObjectOfType<BallStatus>().stopInertia();
			col.transform.position = destination.transform.position;
			       
		}
	}
}

