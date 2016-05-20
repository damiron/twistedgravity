using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class UIHandlerArcade : MonoBehaviour {
    public GameObject[] deadInterface;
    public GameObject[] deadLoggedInInterface;
    public GameObject[] finishInterface;
    public GameObject[] pauseInterface;
    public GameObject[] HUD;
    public string mainMenu = "MainMenu";
    public string nextStage = "Arcade 1-2";
    private bool soundStarted = false;
    private BallStatus ballStatus;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ballStatus == null)
            ballStatus = GameObject.FindWithTag("Player").GetComponent<BallStatus>();
        if (ballStatus.isDead && ballStatus.deadFinishedCounter >= ballStatus.deadFinishedCounterMax)
        {
            foreach (GameObject g in deadInterface)
                g.SetActive(true);
            if (GameObject.FindObjectOfType<Autentication>().autenticated == true)
            {
                foreach (GameObject g in deadLoggedInInterface)
                    g.SetActive(true);
            }
            foreach (GameObject g in HUD)
                g.SetActive(false);
        }
        else if (ballStatus.levelFinished && ballStatus.deadFinishedCounter >= ballStatus.deadFinishedCounterMax)
        {
            foreach (GameObject g in finishInterface)
                g.SetActive(true);
            foreach (GameObject g in HUD)
                g.SetActive(false);
        }        
    }
    public void submitArcadeScoreToLeaderboard()
    {
        if (GameObject.FindObjectOfType<Autentication>().autenticated)
        {
            Social.ReportScore(GameObject.FindObjectOfType<StageScores>().currentArcadeScore, "CgkI-MKE94IEEAIQAg", (bool success) => { });
            PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI-MKE94IEEAIQAg");
        }
    }
    public void MainMenu()
    {
        Time.timeScale = 1.0f;
        GameObject.FindObjectOfType<StageScores>().currentArcadeScore = 0;
        GameObject.FindObjectOfType<MusicManager>().PlayMenuMusic();
        Application.LoadLevel(mainMenu);        
        if (!soundStarted)
        {
            GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();
            soundStarted = true;
        }
    }
    public void NextStage()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel(nextStage);
        if (!soundStarted)
        {
            GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();
            soundStarted = true;
        }
    }
    public void Pause()
    {
        GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();
        foreach (GameObject g in pauseInterface)
            g.SetActive(true);
        foreach (GameObject g in HUD)
            g.SetActive(false);
        ballStatus.paused = true;
        Time.timeScale = 0f;
    }
    public void Continue()
    {
        GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();
        foreach (GameObject g in pauseInterface)
            g.SetActive(false);
        foreach (GameObject g in HUD)
            g.SetActive(true);
        ballStatus.paused = false;
        Time.timeScale = 1.0f;
    }
}
