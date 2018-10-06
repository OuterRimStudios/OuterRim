using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetScore : MonoBehaviour {

    public Text scoreText;
    public string text;
    int currency;

	// Use this for initialization
	void Start () {
        currency = PlayerPrefs.GetInt("Currency");
        currency += PlayerPrefs.GetInt("Score");
        PlayerPrefs.SetInt("Currency", currency);
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

        if(Input.GetKey(KeyCode.R))
        {
            PlayerPrefs.SetInt("Currency", 0);
            print("Currency reset to " + PlayerPrefs.GetInt("Currency"));
        }
    }
}
