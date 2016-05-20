using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ArcadeMaxScoreMenu : MonoBehaviour {

    void Start()
    {
        Text deadText = gameObject.GetComponent<Text>();
        deadText.text = "Max Score: " + GameObject.FindObjectOfType<StageScores>().getMaxArcadeScore();
    }
}
