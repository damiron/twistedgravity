using UnityEngine;
using System.Collections;

public class slowSphereRotation : MonoBehaviour {
    private float currentAngle = 0;
    private int turnSpeed = 3;
	private float angleStep = 0.25f; 
	// Update is called once per frame
	void FixedUpdate () {
        currentAngle += angleStep;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(0, currentAngle, 0), turnSpeed * Time.deltaTime);
	}
}
