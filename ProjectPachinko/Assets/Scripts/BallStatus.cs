using UnityEngine;
using System.Collections;

public class BallStatus : MonoBehaviour {
    public bool isColiding = false;
    public int pickedUpStars = 0;
    public bool levelFinished = false;
    public float finalTime = 0;
    public bool isDead = false;
    public bool paused = false;
    public bool isOnAntiGravity = false;
    public bool isOnAntiGravityX = false;
    public float fixedGravityX = 0;
    public float fixedGravityY = 0;
    public bool isOnAntiGravityY = false;
    public GameObject explosion;
    public GameObject graphicSphere;
    //public GameObject trail;
    //public ParticleSystem trailPS;
    public int deadFinishedCounter = 0;
    public int deadFinishedCounterMax = 115;

    private bool soundStarted = false;

    private int initialEmisionRate = 20;
	// Use this for initialization
	void Start () {
        //trailPS = trail.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!paused && (isDead || levelFinished))
            deadFinishedCounter++;
        //trailPS.emissionRate = gameObject.rigidbody2D.velocity.magnitude * initialEmisionRate;
	}

    void OnCollisionEnter2D()
    {
        isColiding = true;
        gameObject.GetComponentInChildren<Animator>().SetBool("pulse", true);
    }

    void OnCollisionExit2D()
    {
        isColiding = false;
    }

    public void die()
    {
        if (levelFinished)
            return;
        if (!soundStarted)
        {
            GameObject.FindObjectOfType<SoundEffectsHelper>().PlayExplosion();            
            soundStarted = true;
        }
        isDead = true;
        GetComponent<Rigidbody2D>().isKinematic = true;
        graphicSphere.SetActive(false);
        
        explosion.SetActive(true);        
        //trail.SetActive(false);
    }

    public void stopInertia()
    {
        GetComponent<Rigidbody2D>().velocity =  Vector2.zero;
    }
}
