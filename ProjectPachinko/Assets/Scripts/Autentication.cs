using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class Autentication : MonoBehaviour {
    public bool autenticated = true;
	// Use this for initialization
	void Start () {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration();

        PlayGamesPlatform.InitializeInstance(config);
        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = true;
        // Activate the Google Play Games platform
        PlayGamesPlatform.Activate();

        Social.localUser.Authenticate((bool success) =>
        {
            autenticated = success;
        });
	}	
	
}
