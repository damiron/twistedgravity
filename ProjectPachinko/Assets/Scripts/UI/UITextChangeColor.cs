using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UITextChangeColor : MonoBehaviour {
    private Text text = null;
    public float fadeDuration = 4f;
	
	// Update is called once per frame
	void Update () {
        if (text == null)
        {
            text = gameObject.GetComponent<Text>();            
        }
        if (text.canvasRenderer.GetColor() == Color.white)
        {
            text.CrossFadeColor(Color.green, fadeDuration, false, false);
        }
        else if (text.canvasRenderer.GetColor() == Color.green)
        {
            text.CrossFadeColor(Color.magenta, fadeDuration, false, false);
        }
        else if (text.canvasRenderer.GetColor() == Color.magenta)
        {
            text.CrossFadeColor(Color.blue, fadeDuration, false, false);
        }
        else if (text.canvasRenderer.GetColor() == Color.blue)
        {
            text.CrossFadeColor(Color.yellow, fadeDuration, false, false);
        }
        else if (text.canvasRenderer.GetColor() == Color.yellow)
        {
            text.CrossFadeColor(Color.black, fadeDuration, false, false);
        }
        else if (text.canvasRenderer.GetColor() == Color.black)
        {
            text.CrossFadeColor(Color.red, fadeDuration, false, false);
        }
        else if (text.canvasRenderer.GetColor() == Color.red)
        {
            text.CrossFadeColor(Color.cyan, fadeDuration, false, false);
        }
        else if (text.canvasRenderer.GetColor() == Color.cyan)
        {
            text.CrossFadeColor(Color.white, fadeDuration, false, false);
        }
	}
}
