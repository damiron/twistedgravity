using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeLeft : MonoBehaviour {
    public float timeLeft = 50;
    private BallStatus ballStatus;
    private bool isRed = false;
    private float fadeDuration = 2f;
    private Text timerText = null;
    private bool ticked = false;

    void Start()
    {
        ballStatus = GameObject.FindWithTag("Player").GetComponent<BallStatus>();
    }
    void Update()
    {
        if (timerText == null)
        {
            timerText = gameObject.GetComponent<Text>();
        }
        if (!ballStatus.isDead && !ballStatus.levelFinished)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = "" + (int)(timeLeft);
        }
        else if (ballStatus.levelFinished)
        {
            ballStatus.finalTime = (timeLeft);
        }
        if (timeLeft < 21)
        {
            if ((timeLeft - (int)(timeLeft) < 0.1) && !ticked)
            {
                ticked = true;
                GameObject.FindObjectOfType<SoundEffectsHelper>().PlayTick();
            }
            else if (timeLeft - (int)(timeLeft) > 0.1)
            {
                ticked = false;
            }
        }
        if (timeLeft < 21 && !isRed)
        {
            isRed = true;
            timerText.CrossFadeColor(Color.red, fadeDuration, false, false);
        }
        if (timeLeft <= 0)
        {
            ballStatus.die();
        }
    }
}
