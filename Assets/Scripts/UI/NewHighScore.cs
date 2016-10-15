using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class NewHighScore : MonoBehaviour {

    public GameObject newHSPanel;
    public GameObject nextSelected;

    public List<Text> scoreList;
    public List<Text> nameList;

    public Text initial1;
    public Text initial2;
    public Text initial3;

    public Button restartButton;
    public Button quitButton;

    GameObject eventSys;
    EventSystem es;
    string playerName;

    void Start()
    {
        eventSys = GameObject.Find("EventSystem");
        es = eventSys.GetComponent<EventSystem>();
    }

    public void UpdateRank()
    {
        playerName = initial1.text + initial2.text + initial3.text;

        HighScores.AddNewHighScore(playerName, PlayerPrefs.GetInt("Score"));

        newHSPanel.SetActive(false);

        restartButton.interactable = true;
        es.SetSelectedGameObject(restartButton.gameObject);
        quitButton.interactable = true;

        //EventSystem.current.SetSelectedGameObject(nextSelected);
    }
}
