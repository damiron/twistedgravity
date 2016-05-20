using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class UIHandlerMenu : MonoBehaviour {

    public GameObject[] TitleComponents;
    public GameObject[] MenuComponents;
    public GameObject[] MenuLoggedInComponents;
    public GameObject[] StageSelectComponents;
    public GameObject[] StageSelectStageButtons;
    public string[] StageNames;
    public GameObject BonusStageButton;
    public string BonusStageName;
    public GameObject[] ArcadeComponents;
    public GameObject[] ArcadeDetailsComponents;
    public GameObject[] AboutComponents;
    public bool debugMode = false;
    private enum MenuState { Title, Menu, StageSelect, About, Arcade, ArcadeDetails }
    private MenuState state = MenuState.Title;
    public string tutorialStage = "Tutorial";
    private string arcadeWorld = "World 1";
    public GameObject worldNameText;    

	// Update is called once per frame
	void Update () {
        if (state == MenuState.Title && Input.GetMouseButtonDown(0))
        {            
            deactivateTitle();
            activateMenu();
        }
        else if (state == MenuState.About && Input.GetMouseButtonDown(0))
        {
            deactivateAbout();
            activateMenu();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (state)
            {
                case MenuState.Title:
                    Application.Quit();
                    break;
                case MenuState.Menu:
                    deactivateMenu();
                    activateTitle();
                    break;
                case MenuState.StageSelect:
                    GameObject.FindObjectOfType<LoadStage>().returnToStageSelect();
                    deactivateStageSelect();
                    activateMenu();
                    break;
                case MenuState.ArcadeDetails:
                    deactivateArcadeDetails();
                    activateMenu();
                    break;
                case MenuState.Arcade:
                    deactivateArcade();
                    activateMenu();
                    break;
                case MenuState.About:
                    deactivateAbout();
                    activateMenu();
                    break;
            }
        }
	}
    public void callAchivementUI()
    {
        if (GameObject.FindObjectOfType<Autentication>().autenticated)
        {
            Social.ShowAchievementsUI();
        }
    }
    public void callLeaderBoardUI()
    {
        if (GameObject.FindObjectOfType<Autentication>().autenticated)
        {
            Social.ShowLeaderboardUI();
        }
    }
    void activateMenu()
    {
        foreach (GameObject g in MenuComponents)
            g.SetActive(true);
        
        if (GameObject.FindObjectOfType<Autentication>().autenticated == true)
        {
            foreach (GameObject g in MenuLoggedInComponents)
                g.SetActive(true);
        }

        state = MenuState.Menu;
    }
    void deactivateMenu()
    {
        foreach (GameObject g in MenuComponents)
            g.SetActive(false);
        foreach (GameObject g in MenuLoggedInComponents)
            g.SetActive(false);
    }
    void activateStageSelect()
    {

        foreach (GameObject g in StageSelectComponents)
            g.SetActive(true);
        if (debugMode)
        {
            foreach (GameObject g in StageSelectStageButtons)
                g.SetActive(true);
            BonusStageButton.SetActive(true);
        }
        else
        {
            StageSelectStageButtons[0].SetActive(true);
            for (int i = 1; i < StageSelectStageButtons.Length; i++)
            {
                if (GameObject.FindObjectOfType<StageScores>().getTimeLeft(StageNames[i - 1]) == 0 && GameObject.FindObjectOfType<StageScores>().getStars(StageNames[i - 1]) == 0)
                    break;
                else
                    StageSelectStageButtons[i].SetActive(true);
            }
            bool allStarsFound = true;
            foreach (string stage in StageNames)
            {
                if (GameObject.FindObjectOfType<StageScores>().getStars(stage) < 3)
                {
                    allStarsFound = false;
                    break;
                }
            }
            if(allStarsFound)
                BonusStageButton.SetActive(true);
        }
        state = MenuState.StageSelect;
    }
    void deactivateStageSelect()
    {
        foreach (GameObject g in StageSelectComponents)
            g.SetActive(false);
        foreach (GameObject g in StageSelectStageButtons)
            g.SetActive(false);
        BonusStageButton.SetActive(false);
    }
    void activateArcade()
    {
        foreach (GameObject g in ArcadeComponents)
            g.SetActive(true);
        state = MenuState.Arcade;
    }
    void deactivateArcade()
    {
        foreach (GameObject g in ArcadeComponents)
            g.SetActive(false);
    }
    void activateArcadeDetails(string world)
    {
        arcadeWorld = world;
        worldNameText.GetComponent<Text>().text = arcadeWorld;
        GameObject.FindObjectOfType<StageScores>().currentArcadeWorld = world;
        foreach (GameObject g in ArcadeDetailsComponents)
            g.SetActive(true);
        state = MenuState.ArcadeDetails;
    }
    void deactivateArcadeDetails()
    {
        foreach (GameObject g in ArcadeDetailsComponents)
            g.SetActive(false);
    }
    void activateAbout()
    {
        foreach (GameObject g in AboutComponents)
            g.SetActive(true);
        state = MenuState.About;
    }
    void deactivateAbout()
    {
        foreach (GameObject g in AboutComponents)
            g.SetActive(false);
    }
    void deactivateTitle()
    {
        foreach (GameObject g in TitleComponents)
            g.SetActive(false);
    }
    void activateTitle()
    {
        foreach (GameObject g in TitleComponents)
            g.SetActive(true);
        state = MenuState.Title;
    }
    public void NormalModeButtonPress()
    {
        deactivateMenu();
        activateStageSelect();
        GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();
    }

    public void ArcadeModeButtonPress()
    {
        GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();
        deactivateMenu();
        activateArcade();
    }
    public void ArcadeDetails1ButtonPress()
    {
        GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();        
        deactivateArcade();
        activateArcadeDetails("World 1");
    }
    public void ArcadeBackButtonPress()
    {
        GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();
        activateMenu();
        deactivateArcade();
    }
    public void ArcadeDetailsBackButtonPress()
    {
        GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();
        deactivateArcadeDetails();
        activateArcade();        
    }
    public void TutorialButtonPress()
    {        
        GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();
        Application.LoadLevel(tutorialStage);
    }
    public void ContactButtonPress()
    {
        deactivateMenu();
        activateAbout();
        GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();
    }
    public void BackToMenuFromStageSelectPress()
    {
        deactivateStageSelect();
        activateMenu();
        GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();
    }
    public void ExitButtonPress()
    {
        Application.Quit();
    }
}
