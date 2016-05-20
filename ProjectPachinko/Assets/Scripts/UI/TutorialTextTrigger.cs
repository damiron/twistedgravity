using UnityEngine;
using System.Collections;

public class TutorialTextTrigger : MonoBehaviour {
    public GameObject[] deactivate;
    public GameObject[] activate;
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.tag == "Player")
        {
            foreach (GameObject g in deactivate)
                g.SetActive(false);
            foreach (GameObject g in activate)
                g.SetActive(true);
            Destroy(gameObject);
        }
    }
}
