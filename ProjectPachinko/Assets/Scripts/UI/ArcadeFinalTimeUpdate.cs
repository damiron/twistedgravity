using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ArcadeFinalTimeUpdate : MonoBehaviour {
    private int pointsPerExtraSecond = 100;
    void Start()
    {       
        Text finalText = gameObject.GetComponent<Text>();
        BallStatus ballStatus = GameObject.FindWithTag("Player").GetComponent<BallStatus>();
        //Score stageScore = new Score(Application.loadedLevelName, ballStatus.finalTime, ballStatus.pickedUpStars);
        StageScores ss = GameObject.FindObjectOfType<StageScores>();
        //ss.submitScore(stageScore);
        int temporalScore = ss.currentArcadeScore + (int)(ballStatus.finalTime * pointsPerExtraSecond);
        finalText.text = "Time Left: " + ballStatus.finalTime.ToString("n3") +
            "\nScore: " + ss.currentArcadeScore + " + " + (int)(ballStatus.finalTime * pointsPerExtraSecond) + " = " + temporalScore;
        ss.currentArcadeScore += (int)(ballStatus.finalTime * pointsPerExtraSecond);
        ss.submitArcadeScore();
        ss.saveData();
        GameObject.FindObjectOfType<AchivementHandler>().pollAchivementsChallengeMode();
    }
}
