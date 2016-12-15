using UnityEngine;
using System.Collections;
using InControl;
using UnityEngine.EventSystems;

public class PauseGame : MonoBehaviour {

    public GameObject pausePanel;
    public GameObject selectedGameObject;
    bool isPaused;
    InputDevice inputDevice;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        inputDevice = InputManager.ActiveDevice;

	    if(inputDevice.MenuWasPressed || Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isPaused)
            {
                EventSystem.current.SetSelectedGameObject(selectedGameObject);
                isPaused = true;
                Time.timeScale = 0;
                pausePanel.SetActive(true);
            }
            else if(isPaused)
            {
                isPaused = false;
                Time.timeScale = 1;
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
            pausePanel.SetActive(false);
        }
    }
}
