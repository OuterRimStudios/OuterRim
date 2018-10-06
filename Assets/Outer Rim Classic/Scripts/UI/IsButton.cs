using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsButton : MonoBehaviour
{
    public GameObject menu;

    public bool play;
    public bool options;
    public bool quit;
    public bool achievement;
    public bool leaderboard;
    public bool garage;
    public bool credits;

    //public AudioSource mouseOverSound;
    //public AudioSource mouseClickSound;

    private void OnMouseOver()
    {
       // mouseOverSound.Play();
        gameObject.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
    }

    private void OnMouseExit()
    {
        gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
    }

    private void Update()
    {

    }

    public void ButtonFunction()
    {
        if (play)
        {
           // mouseClickSound.Play();
            gameObject.GetComponent<LoadTargetScreenButton>().LoadSceneNum();
        }
        else if (options)
        {
          //  mouseClickSound.Play();
            print("Options");
        }
        else if (quit)
        {
          //  mouseClickSound.Play();
            Application.Quit();
        }
        else if (garage)
        {
          //  mouseClickSound.Play();
            foreach (GameObject go in menu.GetComponent<AllMenuButtons>().mainMenuButtons)
            {
                print("happens");
                go.SetActive(false);
            }
        }
    }
}