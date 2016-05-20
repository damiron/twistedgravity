using UnityEngine;
using System.Collections;

public class BackgroundVFXScr : MonoBehaviour {
    private GameObject ball;
    private BallStatus ballStatus;

    // Update is called once per frame
    void Update()
    {
        if (Application.loadedLevelName == "MainMenu")
            return;
        if (ball == null)
        {
            ball = GameObject.Find("Sphere");
            ballStatus = ball.GetComponent<BallStatus>();
        }
        if (!ballStatus.levelFinished)
            this.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, 14);
    }
}
