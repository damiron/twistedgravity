using UnityEngine;
using System.Collections;

public class PersistentObject : MonoBehaviour
{
    public string tag = "musicLoop";
    // Use this for initialization
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag(tag).Length > 1)
            Destroy(this.gameObject);
        Object.DontDestroyOnLoad(gameObject);
    }
}
