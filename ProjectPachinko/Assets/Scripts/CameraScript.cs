using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
    private GameObject ball;
    private BallStatus ballStatus;

	
	// Update is called once per frame
	void Update () {
        if (ball == null)
        {
            ball = GameObject.Find("Sphere");
            ballStatus = ball.GetComponent<BallStatus>();
        }
        
        if (!ballStatus.levelFinished)
            this.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, -100);
        else
            GetComponent<Camera>().orthographicSize += 0.02f;        
	}
}
