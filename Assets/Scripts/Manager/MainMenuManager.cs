using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

    public GameObject initialMenu;
    public GameObject greeting;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetString("Remember") == "True")
        {
            initialMenu.SetActive(false);
            greeting.GetComponent<Text>().text = "Hello " + PlayerPrefs.GetString("Username") + "!";
            greeting.SetActive(true);
        }
        else
        {
            initialMenu.SetActive(true);
        }
    }
}
