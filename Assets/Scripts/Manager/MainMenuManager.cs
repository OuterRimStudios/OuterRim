using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class MainMenuManager : MonoBehaviour {

    public GameObject initialMenu;
    public GameObject greeting;
    public GameObject startButton;
    public GameObject optionsMenu;
    public GameObject musicManagerPrefab;
    GameObject musicManager;

	// Use this for initialization
	void Start () {
        optionsMenu.SetActive(false);
        if (PlayerPrefs.GetString("Remember") == "True")
        {
            initialMenu.SetActive(false);
            EventSystem.current.SetSelectedGameObject(startButton);
            greeting.GetComponent<Text>().text = "Hello " + PlayerPrefs.GetString("Username") + "!";
            greeting.SetActive(true);
        }
        else
        {
            initialMenu.SetActive(true);
        }

        musicManager = GameObject.Find("MusicManager");
        if(musicManager == null)
        {
            musicManager = Instantiate(musicManagerPrefab);
            musicManager.name = "MusicManager";
        }

        CheckSystem();
    }

    void CheckSystem()
    {
        Analytics.CustomEvent("checkSystem", new Dictionary<string, object>
        {
            { "GPU", SystemInfo.graphicsDeviceName},
            { "CPU", SystemInfo.processorType},
            { "Mem. Size", SystemInfo.systemMemorySize }
        });
    }
}