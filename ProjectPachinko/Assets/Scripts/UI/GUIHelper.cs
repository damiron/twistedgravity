using UnityEngine;
using System.Collections;

public class GUIHelper : MonoBehaviour {
    public GUIStyle style1;
    public GUIStyle buttonStyle;
    public Texture2D star;
    public Texture2D blackStar;
    public GameObject ball;
    public float timeLeft = 50;
    private BallStatus ballStatus;
    public string stageSelectName = "StageSelect";
    public string nextLevelName = "TestStage1";
	// Use this for initialization
	void Start () {
        ballStatus = ball.GetComponent<BallStatus>();
	}
    void Update()
    {
        if (!ballStatus.isDead && !ballStatus.levelFinished)
            timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            ballStatus.die();          
        }
    }
    void OnGUI()
    {
        if (ballStatus.isDead && ballStatus.deadFinishedCounter >= ballStatus.deadFinishedCounterMax)
            drawRestart();
        else if (ballStatus.levelFinished && ballStatus.deadFinishedCounter >= ballStatus.deadFinishedCounterMax)
            drawFinish();
        else
            drawHUD();
    }
    void drawHUD()
    {
        GUI.Label(new Rect((Screen.width) - 120, 10, 120, 56), "" + (int)timeLeft, style1);

        Color cBlackStar = Color.white;
        cBlackStar.a = 0.35f;
        Color cStar = Color.white;
        cStar.a = 0.6f;
        if (ballStatus.pickedUpStars > 0)
        {
            GUI.color = cStar;
            GUI.DrawTexture(new Rect(10, 0, 70, 70), star, ScaleMode.StretchToFill, true, 0);
        }
        else
        {
            GUI.color = cBlackStar;
            GUI.DrawTexture(new Rect(10, 0, 70, 70), blackStar, ScaleMode.StretchToFill, true, 0);
        }
        if (ballStatus.pickedUpStars > 1)
        {
            GUI.color = cStar;
            GUI.DrawTexture(new Rect(80, 0, 70, 70), star, ScaleMode.StretchToFill, true, 0);
        }
        else
        {
            GUI.color = cBlackStar;
            GUI.DrawTexture(new Rect(80, 0, 70, 70), blackStar, ScaleMode.StretchToFill, true, 0);
        }
        if (ballStatus.pickedUpStars > 2)
        {
            GUI.color = cStar;
            GUI.DrawTexture(new Rect(150, 0, 70, 70), star, ScaleMode.StretchToFill, true, 0);
        }
        else
        {
            GUI.color = cBlackStar;
            GUI.DrawTexture(new Rect(150, 0, 70, 70), blackStar, ScaleMode.StretchToFill, true, 0);
        }
    }

    void drawRestart()
    {
        //layout start
        GUI.BeginGroup(new Rect((Screen.width / 10), (Screen.height / 10), (Screen.width / 10) * 8, (Screen.height / 10) * 8));

        //the menu background box
        GUI.Box(new Rect(10, 10, (Screen.width / 10) * 8 - 20, (Screen.height / 10) * 8 - 20), "");

        GUI.Label(new Rect((Screen.width / 2) - 200, (Screen.height / 4) - 100, 200, 100 ), "Try again???", style1);

        if (GUI.Button(new Rect((Screen.width / 10) * 1, (Screen.height / 9) * 2.8f, (Screen.width / 10) * 2.5f, Screen.height / 3), "Restart!", buttonStyle))
        {
            Application.LoadLevel(Application.loadedLevelName);
        }
        if (GUI.Button(new Rect((Screen.width / 10) * 4.5f, (Screen.height / 9) * 2.8f, (Screen.width / 10) * 2.5f, Screen.height / 3), "Stage Select", buttonStyle))
        {
            Application.LoadLevel(stageSelectName);
        }
        GUI.EndGroup();
    }

    void drawFinish()
    {
        //layout start
        GUI.BeginGroup(new Rect((Screen.width / 10), (Screen.height / 10), (Screen.width / 10) * 8, (Screen.height / 10) * 8));

        //the menu background box
        GUI.Box(new Rect(10, 10, (Screen.width / 10) * 8 - 20, (Screen.height / 10) * 8 - 20), "");

        GUI.Label(new Rect((Screen.width / 2) - 200, (Screen.height / 4) - 100, 200, 100), "Good job!!", style1);

        if (GUI.Button(new Rect((Screen.width / 10) * 1, (Screen.height / 9) * 2.8f, (Screen.width / 10) * 2.5f, Screen.height / 3), "Next Level", buttonStyle))
        {
            Application.LoadLevel(nextLevelName);
        }
        if (GUI.Button(new Rect((Screen.width / 10) * 4.5f, (Screen.height / 9) * 2.8f, (Screen.width / 10) * 2.5f, Screen.height / 3), "Stage Select", buttonStyle))
        {
            Application.LoadLevel(stageSelectName);
        }
        GUI.EndGroup();
    }
}
