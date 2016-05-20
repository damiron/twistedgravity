using UnityEngine;
using System.Collections;

public class DisapearIfNotLoggedIn : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (GameObject.FindObjectOfType<Autentication>().autenticated == false)
        {
            gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindObjectOfType<Autentication>().autenticated == false)
        {
            gameObject.SetActive(false);
        }
	}
}
