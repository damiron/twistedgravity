using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeadTextScore : MonoBehaviour {

	// Use this for initialization
    void Start()
    {
        Text deadText = gameObject.GetComponent<Text>();
        deadText.text = "Final Score: " + GameObject.FindObjectOfType<StageScores>().currentArcadeScore;        
    }
}
