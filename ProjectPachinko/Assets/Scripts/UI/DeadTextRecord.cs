using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeadTextRecord : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StageScores ss = GameObject.FindObjectOfType<StageScores>();
        if (ss.currentArcadeScore < ss.getMaxArcadeScore())
        {
            gameObject.GetComponent<Text>().text = "";
        }
        else if (ss.currentArcadeScore > ss.getMaxArcadeScore())
        {
            ss.submitArcadeScore();
            ss.saveData();
            GameObject.FindObjectOfType<AchivementHandler>().pollAchivementsChallengeMode();
        }
	}	
}
