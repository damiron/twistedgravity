using UnityEngine;
using System.Collections;

public class SoundEffectsHelper : MonoBehaviour {
    void Awake()
    {
        /*// Register the singleton
        if (Instance != null)
        {
            Debug.LogError("Multiple instances of SoundEffectsHelper!");
        }*/
    }
    public void PlayPickup()
    {
        this.transform.FindChild("PickupSoundEffect").GetComponent<AudioSource>().Play();
    }
    public void PlayExplosion()
    {
        this.transform.FindChild("ExplosionSoundEffect").GetComponent<AudioSource>().Play();
    } 
    public void PlayVictory()
    {        
        this.transform.FindChild("VictorySoundEffect").GetComponent<AudioSource>().Play();
    }
    public void PlayClick()
    {
        this.transform.FindChild("ClickSoundEffect").GetComponent<AudioSource>().Play();
    }
    public void PlayTick()
    {
        this.transform.FindChild("ClickSoundEffect").GetComponent<AudioSource>().Play();
    }  
	public void PlayPortal()
	{
		this.transform.FindChild("PortalSoundEffect").GetComponent<AudioSource>().Play();
	}  
}
