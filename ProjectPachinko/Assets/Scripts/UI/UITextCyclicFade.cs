using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UITextCyclicFade : MonoBehaviour {
    private Text text = null;
    private float fadeDuration = 4f;
	
	// Update is called once per frame
	void Update () {
        if (text == null)
        {
            text = gameObject.GetComponent<Text>();
        }
        if (text.canvasRenderer.GetAlpha() == 1)
        {
            text.CrossFadeAlpha(0, fadeDuration, false);
        }
        else if (text.canvasRenderer.GetAlpha() == 0)
        {
            text.CrossFadeAlpha(1, fadeDuration, false);
        }
	}
}
