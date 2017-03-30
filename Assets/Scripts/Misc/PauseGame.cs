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
    public Behaviour[] componentsToDisable;

	// Use this for initialization
	void Start () {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
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
                foreach (Behaviour component in componentsToDisable)
                {
                    component.enabled = false;
                }
                Time.timeScale = 0;
                Cursor.visible = true;
                pausePanel.SetActive(true);
            }
            else if(isPaused)
            {
                Unpause();
            }
        }
	}

    public void Unpause()
    {
        if (isPaused)
        {
            isPaused = false;
            foreach(Behaviour component in componentsToDisable)
            {
                component.enabled = true;
            }
            Time.timeScale = 1;
            Cursor.visible = false;
            pausePanel.SetActive(false);
        }
    }
}
