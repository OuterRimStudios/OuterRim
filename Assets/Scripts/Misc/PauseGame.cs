using UnityEngine;
using System.Collections;
using InControl;
using UnityEngine.EventSystems;

public class PauseGame : MonoBehaviour {

    public GameObject pausePanel;
    public GameObject optionsPanel;
    public GameObject selectedGameObject;
    bool isPaused;
    InputDevice inputDevice;

	// Use this for initialization
	void Start () {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        inputDevice = InputManager.ActiveDevice;
        //inputDevice.MenuWasPressed || 
        if (Input.GetButtonDown("Fire3") || Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isPaused)
            {
                EventSystem.current.SetSelectedGameObject(selectedGameObject);
                isPaused = true;
                Time.timeScale = 0;
                Cursor.visible = true;
                pausePanel.SetActive(true);
            }
            else if(isPaused)
            {
                isPaused = false;
                Time.timeScale = 1;
                Cursor.visible = false;
                pausePanel.SetActive(false);
            }
        }
	}

    public void Unpause()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1;
            Cursor.visible = false;
            pausePanel.SetActive(false);
        }
    }
}
