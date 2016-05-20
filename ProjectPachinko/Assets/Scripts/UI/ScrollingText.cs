using UnityEngine;
using System.Collections;

public class ScrollingText : MonoBehaviour {

    private float step = 1f;
    public float stopAtY = 1050;
    public string mainMenuLevelName = "MainMenu";
    private bool finished = false;

	// Update is called once per frame
	void FixedUpdate () {
        if (gameObject.transform.position.y < stopAtY)
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + step, gameObject.transform.position.z);
        else
            finished = true;
        if (Input.GetMouseButton(0) && !finished)
            step = 5f;
        else if (!Input.GetMouseButton(0) && !finished)
            step = 1f;
        else if (Input.GetMouseButton(0) && finished)
        {
            GameObject.FindObjectOfType<MusicManager>().PlayMenuMusic();
            Application.LoadLevel(mainMenuLevelName);
        }
	}
}
