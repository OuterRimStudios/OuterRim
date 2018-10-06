using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class HighScoreHandler : MonoBehaviour {

    public bool mainMenu;

    public GameObject newHSPanel;
    public GameObject confirmButton;

    public List<Text> scoreList;
    public List<Text> nameList;

    public Button restartButton;
    public Button quitButton;

    public static int rankToUpdate;

    public static int currentScore;

    public List<LeaderboardInfo> leaderboardInfo;

    string scoreString;
    string scoreText;
    string nameString;

	// Use this for initialization
	IEnumerator Start () 
    {
        Time.timeScale = 1;
        currentScore = PlayerPrefs.GetInt("Score");
        leaderboardInfo = new List<LeaderboardInfo>(10);

        for(int i = 1; i <= 10; i++)
        {
            scoreString = "Rank" + i.ToString() + "Score";
            nameString = "Rank" + i.ToString() + "Name";
            
            leaderboardInfo.Add(new LeaderboardInfo(PlayerPrefs.GetInt(scoreString), PlayerPrefs.GetString(nameString)));

            UpdateLeaderboardGraphics();
        }

        yield return new WaitForSeconds(0.05f);

        if (!mainMenu)
        {
            //EventSystem.current.SetSelectedGameObject(confirmButton);

            for (int j = 0; j < 10; j++)
            {
                if (currentScore > leaderboardInfo[j].Score)
                {
                    newHSPanel.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(confirmButton);

                    if (restartButton)
                        restartButton.interactable = false;
                    else
                        Debug.LogError("No restart button assigned");

                    if (quitButton)
                        quitButton.interactable = false;
                    else
                        Debug.LogError("No quit button assigned");

                    rankToUpdate = j + 1;
                    break;
                }
                else
                {
                    EventSystem.current.SetSelectedGameObject(restartButton.gameObject);
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("r")) 
        {
            for(int i = 1; i <= 10; i++)
            {
                scoreString = "Rank" + i.ToString() + "Score";
                nameString = "Rank" + i.ToString() + "Name";

                PlayerPrefs.SetInt(scoreString, 0);
                PlayerPrefs.SetString(nameString, "");                

                leaderboardInfo[i - 1].Score = PlayerPrefs.GetInt(scoreString);
                leaderboardInfo[i - 1].Name = PlayerPrefs.GetString(nameString);

                UpdateLeaderboardGraphics();
            }
        }
	}

    public void UpdateLeaderboardInfo(int score, string name, int index)
    {
        leaderboardInfo.Insert(index, new LeaderboardInfo(score, name));

        if (leaderboardInfo.Count > 10)
        {
            leaderboardInfo.RemoveAt(10);
        }

        UpdatePlayerPrefs();
    }

    public void  UpdatePlayerPrefs()
    {
        for(int i = 1; i <= 10; i++)
        {
            scoreString = "Rank" + i.ToString() + "Score";
            nameString = "Rank" + i.ToString() + "Name";

            PlayerPrefs.SetInt(scoreString, leaderboardInfo[i - 1].Score);
            PlayerPrefs.SetString(nameString, leaderboardInfo[i - 1].Name);
        }

        PlayerPrefs.Save();

        UpdateLeaderboardGraphics();
    }
    
    public void UpdateLeaderboardGraphics()
    {
        for(int i = 1; i <= 10; i++)
        {
            scoreString = "Rank" + i.ToString() + "Score";
            nameString = "Rank" + i.ToString() + "Name";

            scoreText = PlayerPrefs.GetInt(scoreString).ToString();
            scoreList[i - 1].text = scoreText;

            nameList[i - 1].text = PlayerPrefs.GetString(nameString);
        }
    } 
}

public class LeaderboardInfo
{
    int score;
    string name;

    public LeaderboardInfo(int aScore, string aName)
    {
        score = aScore;
        name = aName;
    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
}
