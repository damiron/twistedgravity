using UnityEngine;
using System.Collections;

public class MainMenuBackground : MonoBehaviour {
    public GameObject maze;
    private float angleStep = 0.15f;
    private int turnSpeed = 1;
    private float currentAngle = 0;
    public bool invertDirection = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(!invertDirection)
            currentAngle -= angleStep;
        else
            currentAngle += angleStep;
        maze.transform.rotation = Quaternion.Slerp(maze.transform.rotation, Quaternion.Euler(0, 0, currentAngle), turnSpeed * Time.deltaTime);
	}

    void UpdateRotationKeyboard()
    {/*
        if (axisx != 0)
        {
            if (axisx < 0)
                currentAngle += angleStep;
            else
                currentAngle -= angleStep;
        }*/
        
    }
}
