using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class MainMenuManager : MonoBehaviour {

    public GameObject initialMenu;
    public GameObject greeting;
    public GameObject startButton;

	// Use this for initialization
	void Start () {
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
