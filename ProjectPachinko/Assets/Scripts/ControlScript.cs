using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControlScript : MonoBehaviour {

	public GameObject ball;
    public GameObject maze;

    private Vector2 jumpForce = new Vector2(0, 350);
    private float currentAngle = 0;
    private float finishingAngle = 0;
    private int turnSpeed = 10;
	private int turnSpeedBackground = 1;
    private float angleStep = 3;
    private float gravityModule = 30;
    private BallStatus ballStatus;


	// Use this for initialization
	void Start ()
    {
        ballStatus = ball.GetComponent<BallStatus>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (ballStatus.levelFinished)
        {
            finishingAngle += (angleStep);
            maze.transform.rotation = Quaternion.Slerp(maze.transform.rotation, Quaternion.Euler(finishingAngle, 0, 0), (turnSpeed / 2) * Time.deltaTime);
            //maze.transform.position = new Vector3(maze.transform.position.x, maze.transform.position.y, maze.transform.position.z + 0.1f);
            return;
        }
        else if (ballStatus.isDead)
            return;
        if (Input.GetKey(KeyCode.Escape))
        {
            UIHandler ui = GameObject.FindWithTag("uihandler").GetComponent<UIHandler>();
            ui.Pause();
        }
        if (Application.platform == RuntimePlatform.Android)
            UpdateRotationAccelerometer();
        else
            UpdateRotationKeyboard();        
	}

    void UpdateRotationKeyboard()
    {
        if(!ballStatus.isOnAntiGravity)
            Physics2D.gravity = new Vector2(0, (-1) * gravityModule);
        float axisx = Input.GetAxis("Horizontal");
        if (axisx != 0)
        {
            if (axisx < 0)            
                currentAngle += angleStep;            
            else            
                currentAngle -= angleStep;            
        }        
        maze.transform.rotation = Quaternion.Slerp(maze.transform.rotation, Quaternion.Euler(0, 0, currentAngle), turnSpeed * Time.deltaTime);
    }

    void UpdateRotationAccelerometer()
    {
        Vector2 accel = new Vector2(Input.acceleration.x * 1.2f , Input.acceleration.y * 1.2f);
		if(accel.x > 1)
			accel.x = 1;
		else if(accel.x < -1)
			accel.x = -1;
		if(accel.y > 1)
			accel.y = 1;
		else if(accel.y < -1)
			accel.y = -1;
        if(ballStatus.isOnAntiGravityX)
        {
            Vector2 grav = new Vector2(ballStatus.fixedGravityX, Input.acceleration.y * gravityModule);
            Physics2D.gravity = grav;
        }
        else if (ballStatus.isOnAntiGravityY)
        {
            Vector2 grav = new Vector2(Input.acceleration.x * gravityModule, ballStatus.fixedGravityY);
            Physics2D.gravity = grav;
        }
        else if(!ballStatus.isOnAntiGravity)
        {
            Vector2 grav = new Vector2(Input.acceleration.x * gravityModule, Input.acceleration.y * gravityModule);
            Physics2D.gravity = grav;
        }        
        float angle = Vector2.Angle(accel, new Vector2(0, -1));
        if (accel.x < 0)
            angle = 360 - angle;        
    }
    
}
