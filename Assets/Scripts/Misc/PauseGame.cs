using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {

    public GameObject pausePanel;
    bool isPaused;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isPaused)
            {
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
