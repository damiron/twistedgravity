using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour {
    private GameObject ball;
    private BallStatus ballStatus;
    void Start()
    {
        Resize();
    }
    void Update()
    {
        if (Application.loadedLevelName == "MainMenu")
            return;
        if (ball == null)
        {
            ball = GameObject.Find("Sphere");
            ballStatus = ball.GetComponent<BallStatus>();
        }
        if (!ballStatus.levelFinished)
            this.transform.position = new Vector3(ball.transform.position.x, ball.transform.position.y, 15);
        else
            Resize();
    }

    void Resize()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        if (mr == null) return;

        transform.localScale = new Vector3(1, 1, 1);

        //float width = mr.materials[0].bounds.size.x;
        //float height = mr.bounds.size.z;


        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        Vector3 xWidth = transform.localScale;
        xWidth.x = worldScreenWidth/8;
        transform.localScale = xWidth;
        Vector3 yHeight = transform.localScale;
        yHeight.z = worldScreenHeight/7;
        transform.localScale = yHeight;

    }
}
