using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class EnterName : MonoBehaviour {

    public Text textBox;
    public Text greeting;
    public InputField inField;
    public GameObject initialMenu;
    public GameObject warning;
    public GameObject startButton;
    public static string username;
    bool remember;
    bool activated;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnterHSName()
    {
        PlayerPrefs.SetString("HighScoreName", inField.text);
    }

    public void ConfirmName()
    {
        if (textBox.text.Trim().Length > 0)
        {
            username = textBox.text;
            if (remember)
            {
                PlayerPrefs.SetString("Username", username);
            }
            UpdateGreeting();
            initialMenu.SetActive(false);
            EventSystem.current.SetSelectedGameObject(startButton);
        }
        else
        {
            StartCoroutine(ActivateWarning());
        }
    }

    IEnumerator ActivateWarning()
    {
        if (!activated)
        {
            activated = true;
            warning.SetActive(true);
            yield return new WaitForSeconds(2f);
            warning.SetActive(false);
            activated = false;
        }
    }

    public void UpdateRememberStatus()
    {
        remember = !remember;
        PlayerPrefs.SetString("Remember", remember.ToString());
        print(remember.ToString());
    }

    public void UpdateGreeting()
    {
        greeting.text = "Hello " + username + "!";
        greeting.gameObject.SetActive(true);
    }
}