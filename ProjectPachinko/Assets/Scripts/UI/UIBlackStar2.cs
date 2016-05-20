using UnityEngine;
using System.Collections;

public class UIBlackStar2 : MonoBehaviour {
    private BallStatus bs = null;
	// Update is called once per frame
	void Update () {
        if (bs == null)
            bs = GameObject.FindWithTag("Player").GetComponent<BallStatus>();
	    if(bs.pickedUpStars>1)
            gameObject.SetActive(false);
	}
}
