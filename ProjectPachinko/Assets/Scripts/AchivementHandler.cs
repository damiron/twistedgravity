using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class AchivementHandler : MonoBehaviour {
    public string labyrinthStageName = "Stage 1-4";
    public string halfwayStageName = "Stage 1-5";
    public string amourStageName = "Stage 1-9";
    public string fiveElemStageName = "Stage 1-10";
    public string challengeHalfwayStageName = "Arcade 1-5";
    public string challengeAmourStageName = "Arcade 1-9";
    public string challengeWorldName = "World 1";
    public void pollAchivementsNormalMode()
    {
        if (GameObject.FindObjectOfType<Autentication>().autenticated == false)
        {
            return;
        }
        //print("Achivements being polled. 1-1 time = " + GameObject.FindObjectOfType<StageScores>().getTimeLeft("Stage 1-1"));
        if (GameObject.FindObjectOfType<StageScores>().getTimeLeft(labyrinthStageName) != 0 && GameObject.FindObjectOfType<StageScores>().getStars(labyrinthStageName) == 3)
            activateLabyrinth();
        if (GameObject.FindObjectOfType<StageScores>().getTimeLeft(halfwayStageName) != 0)
            activateHalfway();
        if (GameObject.FindObjectOfType<StageScores>().getTimeLeft(amourStageName) != 0)
            activateAmour();
        if (GameObject.FindObjectOfType<StageScores>().getTimeLeft(fiveElemStageName) != 0)
            activateFiveElem();
        if (GameObject.FindObjectOfType<StageScores>().world1isCompleted())
            activateCompletionist1();
    }
    public void pollAchivementsChallengeMode()
    {
        if (GameObject.FindObjectOfType<Autentication>().autenticated == false)
        {
            return;
        }
        if (GameObject.FindObjectOfType<StageScores>().getMaxArcadeScore() >= 15000)
            activateGoldenMilestone1();
    }
    public void pollAchivementsChallengeMode(string completedStageName)
    {
        if (GameObject.FindObjectOfType<Autentication>().autenticated == false)
        {
            return;
        }
        if (GameObject.FindObjectOfType<StageScores>().getMaxArcadeScore() >= 15000)
            activateGoldenMilestone1();
        if (completedStageName == challengeHalfwayStageName)
            activateGoldenHalfway();
        if (completedStageName == challengeAmourStageName)
            activateGoldenGod1();
    }
    public void activateLabyrinth()
    {
        Social.ReportProgress("CgkI-MKE94IEEAIQFA", 100.0f, (bool success) => { });
    }
    public void activateHalfway()
    {        
        Social.ReportProgress("CgkI-MKE94IEEAIQEQ", 100.0f, (bool success) => { });
    }
    public void activateAmour()
    {        
        Social.ReportProgress("CgkI-MKE94IEEAIQDw", 100.0f, (bool success) => { });        
    }
    public void activateFiveElem()
    {
        Social.ReportProgress("CgkI-MKE94IEEAIQDg", 100.0f, (bool success) => { });        
    }
    public void activateCompletionist1()
    {       
        Social.ReportProgress("CgkI-MKE94IEEAIQEA", 100.0f, (bool success) => { });        
    }
    public void activateGoldenHalfway()
    {        
        Social.ReportProgress("CgkI-MKE94IEEAIQEg", 100.0f, (bool success) => { });        
    }
    public void activateGoldenMilestone1()
    {        
        Social.ReportProgress("CgkI-MKE94IEEAIQEw", 100.0f, (bool success) => { });        
    }
    public void activateGoldenGod1()
    {        
        Social.ReportProgress("CgkI-MKE94IEEAIQDQ", 100.0f, (bool success) => { });        
    }
}
