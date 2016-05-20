using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UITextFade : MonoBehaviour {
    public float fadeDuration = 2.5f;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Text>().CrossFadeAlpha(0, fadeDuration, false);        
	}
}
