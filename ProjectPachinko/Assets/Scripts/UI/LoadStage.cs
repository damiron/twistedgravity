using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadStage : MonoBehaviour {
    private string arcade1 = "Arcade 1-1";    
    public string name;
    public int stars;
    public float timeLeft;
    public GameObject[] detailsInterface;
    public GameObject[] detailsIfScore;
    public GameObject[] StageSelectComponents;
    public GameObject[] StageSelectStageButtons;
    public string[] StageNames;
    public GameObject BonusStageButton;
    public string BonusStageName;
    public GameObject stageNameText;
    public GameObject timeLeftText;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public void LoadArcade1()
    {
        name = arcade1;        
        LoadSelectedStage();
    }

    public void DetailsStage1()
    {
        GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();
        name = StageNames[0];        
        stars = GameObject.FindObjectOfType<StageScores>().getStars(name);
        timeLeft = GameObject.FindObjectOfType<StageScores>().getTimeLeft(name);
        activateDetails();
    }
    public void DetailsStage2()
    {
        GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();
        name = StageNames[1];
        stars = GameObject.FindObjectOfType<StageScores>().getStars(name);
        timeLeft = GameObject.FindObjectOfType<StageScores>().getTimeLeft(name);
        activateDetails();
    }
    public void DetailsStage3()
    {
        GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();
        name = StageNames[2];
        stars = GameObject.FindObjectOfType<StageScores>().getStars(name);
        timeLeft = GameObject.FindObjectOfType<StageScores>().getTimeLeft(name);
        activateDetails();
    }
    public void DetailsStage4()
    {
        GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();
        name = StageNames[3];
        stars = GameObject.FindObjectOfType<StageScores>().getStars(name);
        timeLeft = GameObject.FindObjectOfType<StageScores>().getTimeLeft(name);
        activateDetails();
    }
    public void DetailsStage5()
    {
        GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();
        name = StageNames[4];
        stars = GameObject.FindObjectOfType<StageScores>().getStars(name);
        timeLeft = GameObject.FindObjectOfType<StageScores>().getTimeLeft(name);
        activateDetails();
    }
    public void DetailsStage6()
    {
        GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();
        name = StageNames[5];
        stars = GameObject.FindObjectOfType<StageScores>().getStars(name);
        timeLeft = GameObject.FindObjectOfType<StageScores>().getTimeLeft(name);
        activateDetails();
    }
    public void DetailsStage7()
    {
        GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();
        name = StageNames[6];
        stars = GameObject.FindObjectOfType<StageScores>().getStars(name);
        timeLeft = GameObject.FindObjectOfType<StageScores>().getTimeLeft(name);
        activateDetails();
    }
    public void DetailsStage8()
    {
        GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();
        name = StageNames[7];
        stars = GameObject.FindObjectOfType<StageScores>().getStars(name);
        timeLeft = GameObject.FindObjectOfType<StageScores>().getTimeLeft(name);
        activateDetails();
    }
    public void DetailsStage9()
    {
        GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();
        name = StageNames[8];
        stars = GameObject.FindObjectOfType<StageScores>().getStars(name);
        timeLeft = GameObject.FindObjectOfType<StageScores>().getTimeLeft(name);
        activateDetails();
    }
	public void DetailsStage10()
	{
		GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();
        name = BonusStageName;
		stars = GameObject.FindObjectOfType<StageScores>().getStars(name);
		timeLeft = GameObject.FindObjectOfType<StageScores>().getTimeLeft(name);
		activateDetails();
	}
    public void activateDetails()
    {
        stageNameText.GetComponent<Text>().text = name;            
        foreach (GameObject di in detailsInterface)
            di.SetActive(true);
        if (timeLeft > 0)
        {
            foreach (GameObject dis in detailsIfScore)
                dis.SetActive(true);
            timeLeftText.GetComponent<Text>().text = "Max Time Left: " + timeLeft.ToString("n3");
            activateDetailStars();
        }
        foreach (GameObject di in StageSelectStageButtons)
            di.SetActive(false);
        BonusStageButton.SetActive(false);
    }
    public void returnToStageSelect()
    {
        GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();
        foreach (GameObject di in detailsInterface)
            di.SetActive(false);
        foreach (GameObject dis in detailsIfScore)
            dis.SetActive(false);
        deactivateDetailStars();

        foreach (GameObject g in StageSelectComponents)
            g.SetActive(true);
        if (GameObject.FindObjectOfType<UIHandlerMenu>().debugMode)
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
            if (allStarsFound)
                BonusStageButton.SetActive(true);
        }
    }
    public void LoadSelectedStage()
    {
        GameObject.FindObjectOfType<MusicManager>().PlayWorld1Music();
        GameObject.FindObjectOfType<SoundEffectsHelper>().PlayClick();
        Application.LoadLevel(name);
    }
    public void activateDetailStars()
    {
        if (stars >= 1)
        {
            star1.SetActive(true);
        }
        if (stars >= 2)
        {
            star2.SetActive(true);
        }
        if (stars >= 3)
        {
            star3.SetActive(true);
        }
    }
    public void deactivateDetailStars()
    {
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
    }

    public void loadEndScene1()
    {
        Application.LoadLevel("EndWorld1");
    }
    public void loadEndScene2()
    {
        Application.LoadLevel("SecretEndWorld1");
    }
    public void loadEndScene3()
    {
        Application.LoadLevel("ChallengeEndWorld1");
    }
}
