using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetScore : MonoBehaviour {

    public Text scoreText;
    public string text;

	// Use this for initialization
	void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {

        if (text == "Score")
        {
            scoreText.text = "Score: " + PlayerPrefs.GetInt("Score");
        }
        else if (text == "High Score")
        {
            if (PlayerPrefs.GetString("HighScoreName") != "")
            {
                scoreText.text = PlayerPrefs.GetString("HighScoreName") + "'s " + "Current \n High Score: " + PlayerPrefs.GetInt("HighScore");
            }
            else
            {
                scoreText.text = "Current \n High Score: " + PlayerPrefs.GetInt("HighScore");
            }
        }
    }
}
