using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    public void PlayWorld1Music()
    {
        this.transform.FindChild("TG 03").GetComponent<AudioSource>().Stop();
        this.transform.FindChild("TG 01").GetComponent<AudioSource>().Play();
    }
    public void PlayMenuMusic()
    {
        this.transform.FindChild("TG 01").GetComponent<AudioSource>().Stop();
        this.transform.FindChild("TG 03").GetComponent<AudioSource>().Play();
    } 
}
