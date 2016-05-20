using UnityEngine;
using System.Collections;

public class AvoidScreenFade : MonoBehaviour {

    // Use this for initialization
    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }		
}
