using UnityEngine;
using System.Collections;
using InControl;
using UnityEngine.EventSystems;

public class PauseGame : MonoBehaviour {

    public GameObject pausePanel;
    public GameObject optionsPanel;
    public GameObject selectedGameObject;
    bool isPaused;

    void Start()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public void Pause()
    {
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0;
            Cursor.visible = true;
            pausePanel.SetActive(true);
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
