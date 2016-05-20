using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIStar1 : MonoBehaviour {
    private BallStatus bs = null;
    // Update is called once per frame
    void Update()
    {
        if (bs == null)
            bs = GameObject.FindWithTag("Player").GetComponent<BallStatus>();
        if (bs.pickedUpStars > 0)
            gameObject.GetComponent<Image>().enabled = true;
        else
            gameObject.GetComponent<Image>().enabled = false;
    }
}
