using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class UIHandler : MonoBehaviour {
    public GameObject[] deadInterface;
    public GameObject[] finishInterface;
    public GameObject[] logedInFinishInterface;
    public GameObject[] pauseInterface;
    public GameObject[] HUD;
    public string stage11 = "Stage 1-1";
    public string stage12 = "Stage 1-2";
    public string stage13 = "Stage 1-3";
    public string stage14 = "Stage 1-4";
    public string stage15 = "Stage 1-5";
    public string stage16 = "Stage 1-6";
    public string stage17 = "Stage 1-7";
    public string stage18 = "Stage 1-8";
    public string stage19 = "Stage 1-9";
    public string stage110 = "Stage 1-10";
    public string mainMenu = "StageSelect";
    public string nextStage = "Stage2";
    private bool soundStarted = false;
    private BallStatus ballStatus;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (ballStatus == null)
            ballStatus = GameObject.FindWithTag("Player").GetComponent<BallStatus>();
        if (ballStatus.isDead && ballStatus.deadFinishedCounter >= ballStatus.deadFinishedCounterMax)
        {
            foreach (GameObject g in deadInterface)
                g.SetActive(true);
            foreach (GameObject g in HUD)
                g.SetActive(false);
        }
        else if (ballStatus.levelFinished && ballStatus.deadFinishedCounter >= ballStatus.deadFinishedCounterMax)
        {
            foreach (GameObject g in finishInterface)
                g.SetActive(true);
            if (GameObject.FindObjectOfType<Autentication>().autenticated == true)
            {
                foreach (GameObject g in logedInFinishInterface)
                    g.SetActive(true);
            }
            foreach (GameObject g in HUD)
                g.SetActive(false);
        }
        /*else if (ballStatus.paused)
        {
            foreach (GameObject g in pauseInterface)
                g.SetActive(true);
            foreach (GameObject g in HUD)
                g.SetActive(false);
        }*/
	}

    public void ResetStage()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel(Application.loadedLevelName);
        if (!soundStarted)
        {
            GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();
            soundStarted = true;
        }
    }
    public void MainMenu()
    {
        Time.timeScale = 1.0f;
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
    public void submitTimeToLeaderboards()
    {
        if (GameObject.FindObjectOfType<Autentication>().autenticated == false)
        {
            return;
        }
        else if (Application.loadedLevelName == stage11)
        {
            Social.ReportScore((long)(GameObject.FindWithTag("Player").GetComponent<BallStatus>().finalTime * 1000), "CgkI-MKE94IEEAIQFQ", (bool success) => { });
            PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI-MKE94IEEAIQFQ");
        }
        else if (Application.loadedLevelName == stage12)
        {
            Social.ReportScore((long)(GameObject.FindWithTag("Player").GetComponent<BallStatus>().finalTime * 1000), "CgkI-MKE94IEEAIQFg", (bool success) => { });
            PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI-MKE94IEEAIQFg");
        }
        else if (Application.loadedLevelName == stage13)
        {
            Social.ReportScore((long)(GameObject.FindWithTag("Player").GetComponent<BallStatus>().finalTime * 1000), "CgkI-MKE94IEEAIQFw", (bool success) => { });
            PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI-MKE94IEEAIQFw");
        }
        else if (Application.loadedLevelName == stage14)
        {
            Social.ReportScore((long)(GameObject.FindWithTag("Player").GetComponent<BallStatus>().finalTime * 1000), "CgkI-MKE94IEEAIQGA", (bool success) => { });
            PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI-MKE94IEEAIQGA");
        }
        else if (Application.loadedLevelName == stage15)
        {
            Social.ReportScore((long)(GameObject.FindWithTag("Player").GetComponent<BallStatus>().finalTime * 1000), "CgkI-MKE94IEEAIQGQ", (bool success) => { });
            PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI-MKE94IEEAIQGQ");
        }
        else if (Application.loadedLevelName == stage16)
        {
            Social.ReportScore((long)(GameObject.FindWithTag("Player").GetComponent<BallStatus>().finalTime * 1000), "CgkI-MKE94IEEAIQGg", (bool success) => { });
            PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI-MKE94IEEAIQGg");
        }
        else if (Application.loadedLevelName == stage17)
        {
            Social.ReportScore((long)(GameObject.FindWithTag("Player").GetComponent<BallStatus>().finalTime * 1000), "CgkI-MKE94IEEAIQGw", (bool success) => { });
            PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI-MKE94IEEAIQGw");
        }
        else if (Application.loadedLevelName == stage18)
        {
            Social.ReportScore((long)(GameObject.FindWithTag("Player").GetComponent<BallStatus>().finalTime * 1000), "CgkI-MKE94IEEAIQHA", (bool success) => { });
            PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI-MKE94IEEAIQHA");
        }
        else if (Application.loadedLevelName == stage19)
        {
            Social.ReportScore((long)(GameObject.FindWithTag("Player").GetComponent<BallStatus>().finalTime * 1000), "CgkI-MKE94IEEAIQHQ", (bool success) => { });
            PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI-MKE94IEEAIQHQ");
        }
        else if (Application.loadedLevelName == stage110)
        {
            Social.ReportScore((long)(GameObject.FindWithTag("Player").GetComponent<BallStatus>().finalTime * 1000), "CgkI-MKE94IEEAIQDA", (bool success) => { });
            PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI-MKE94IEEAIQDA");
        }
    }
}
