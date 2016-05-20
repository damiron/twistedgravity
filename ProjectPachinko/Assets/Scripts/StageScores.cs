using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;


public class Score
{
    public Score(string name, float time, int star)
    {
        stageName = name;
        timeLeft = time;
        stars = star;
    }
    public string stageName;
    public float timeLeft;
    public int stars;    
}
public class ArcadeScore
{
    public ArcadeScore(string name, int points)
    {
        this.worldName = name;
        this.points = points;
    }
    public string worldName;
    public int points;
}
public class StageScores : MonoBehaviour {
    public int currentArcadeScore = 0;
    public string currentArcadeWorld = "World 1";
    //public int maxArcadeScore = 0;
    private string filePath;
    public List<Score> scores;
    public List<ArcadeScore> arcadeScores;
    void Start()
    {
        filePath = Application.persistentDataPath + "/data";
        scores = new List<Score>();
        arcadeScores = new List<ArcadeScore>();
        loadData();
    }

    public void submitScore(Score sc)
    {
        bool found = false;
        foreach (Score temp in scores)
        {
            if (temp.stageName == sc.stageName)
            {
                found = true;
                //If there was a previous stage score we get the highest values of the two
                if (temp.timeLeft < sc.timeLeft)
                {
                    temp.timeLeft = sc.timeLeft;
                }
                if (temp.stars < sc.stars)
                {
                    temp.stars = sc.stars;
                }
                break;
            }
        }
        if (!found)
        {
            //There was not a previous stage score for this stage, so we store it.
            scores.Add(sc);
        }
    }
    public void submitArcadeScore()
    {
        bool found = false;
        foreach (ArcadeScore temp in arcadeScores)
        {
            if (temp.worldName == currentArcadeWorld)
            {
                found = true;
                //If there was a previous arcade score we get the highest points                
                if (temp.points < currentArcadeScore)
                {
                    temp.points = currentArcadeScore;
                }
                break;
            }
        }
        if (!found)
        {
            //There was not a previous stage score for this stage, so we store it.
            arcadeScores.Add(new ArcadeScore(currentArcadeWorld, currentArcadeScore));
        }
    }
    public float getTimeLeft(string stageName)
    {
        foreach (Score temp in scores)
        {
            if (temp.stageName == stageName)
            {
                return temp.timeLeft;
            }
        }
        return 0;
    }
    public int getStars(string stageName)
    {
        foreach (Score temp in scores)
        {
            if (temp.stageName == stageName)
            {
                return temp.stars;
            }
        }
        return 0;
    }
    public int getMaxArcadeScore()
    {
        foreach (ArcadeScore temp in arcadeScores)
        {
            if (temp.worldName == currentArcadeWorld)
            {
                return temp.points;
            }
        }
        return 0;
    }
    public bool world1isCompleted()//returns true if you have ALL stars in world 1, including secret level
    {
        if (scores.Count != 10)
            return false;
        foreach (Score temp in scores)
        {
            if (temp.stars != 3)
                return false;
        }
        return true;
    }
    public void saveData()
    {
        string[] serializedLines = new string[scores.Count + 1];
        int i = 0;
        foreach (ArcadeScore temp in arcadeScores)
        {
            serializedLines[i] = temp.worldName + ";" + temp.points;
            i++;
        }
        foreach (Score temp in scores)
        {
            serializedLines[i] = temp.stageName + ";" + temp.stars + ";" + temp.timeLeft;
            i++;
        }
        File.WriteAllLines(filePath, serializedLines);
    }

    public void loadData()
    {
        if (!File.Exists(filePath))
        {
            return;
        }
        string[] serializedLines = File.ReadAllLines(filePath);

        for(int i = 0; i<serializedLines.Length; i++)
        {
            string[] splittedLines = serializedLines[i].Split(';');
            if (splittedLines.Length == 2)
            {
                arcadeScores.Add(new ArcadeScore(splittedLines[0], Int32.Parse(splittedLines[1])));
            }
            else if (splittedLines.Length == 3)
            {
                scores.Add(new Score(splittedLines[0], float.Parse(splittedLines[2]), Int32.Parse(splittedLines[1])));
            }
            else
            {
                //Wrong file format
                Debug.Log(splittedLines.Length);
                return;
            }
        }        
    }
}
