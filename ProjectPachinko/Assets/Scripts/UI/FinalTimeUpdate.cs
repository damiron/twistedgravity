using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalTimeUpdate : MonoBehaviour {
	// Use this for initialization
	void Start () {
        Text finalText = gameObject.GetComponent<Text>();
        BallStatus ballStatus = GameObject.FindWithTag("Player").GetComponent<BallStatus>();
        finalText.text = "Time Left: " + ballStatus.finalTime.ToString("n3");
        Score stageScore = new Score(Application.loadedLevelName, ballStatus.finalTime, ballStatus.pickedUpStars);
        StageScores ss = GameObject.FindObjectOfType<StageScores>();
        ss.submitScore(stageScore);
        ss.saveData();
        GameObject.FindObjectOfType<AchivementHandler>().pollAchivementsNormalMode();
	}
}
