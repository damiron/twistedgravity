using UnityEngine;
using System.Collections;

public class StarScript : MonoBehaviour {
    private float currentAngle = 0;
    private int turnSpeed = 10;
    private float angleStep = 1.5f;
    private int pointsForAStar = 1000;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        currentAngle += angleStep;
        if (currentAngle > 360)
            currentAngle -= 360;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(0, currentAngle, 0), turnSpeed * Time.deltaTime);
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player" && !col.GetComponent<BallStatus>().levelFinished)
        {
            col.GetComponent<BallStatus>().pickedUpStars++;
            GameObject.FindObjectOfType<StageScores>().currentArcadeScore += pointsForAStar;
            GameObject.FindObjectOfType<SoundEffectsHelper>().PlayPickup();
            Destroy(gameObject);
        }
    }
}
