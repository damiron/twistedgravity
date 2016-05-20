using UnityEngine;
using System.Collections;

public class ClearArcadeScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.FindObjectOfType<StageScores>().currentArcadeScore = 0;
	}	
	
}
