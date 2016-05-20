using UnityEngine;
using System.Collections;

public class TriggerReverse : MonoBehaviour {
    public bool direction = false;
    private MainMenuBackground bck = null;
    
    void OnTriggerStay2D(Collider2D col)
    {
        if (bck == null)
            bck = GameObject.FindObjectOfType<MainMenuBackground>();

        bck.invertDirection = direction;
    }
}
