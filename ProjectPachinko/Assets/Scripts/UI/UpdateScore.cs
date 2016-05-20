using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour {
    private Text scoreText = null;
	private StageScores stages = null;
	// Update is called once per frame
	void Update () {
        if (scoreText == null)
        {
            scoreText = gameObject.GetComponent<Text>();
        }
        if (stages == null)
        {
            stages =  GameObject.FindObjectOfType<StageScores>();
        }
        scoreText.text = "Score: " + stages.currentArcadeScore;
	}
}
