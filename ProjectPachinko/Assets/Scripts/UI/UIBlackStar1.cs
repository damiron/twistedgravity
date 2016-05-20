using UnityEngine;
using System.Collections;

public class UIBlackStar1 : MonoBehaviour {
    private BallStatus bs = null;
    // Update is called once per frame
    void Update()
    {
        if (bs == null)
            bs = GameObject.FindWithTag("Player").GetComponent<BallStatus>();
        if (bs.pickedUpStars > 0)
            gameObject.SetActive(false);
    }
}
