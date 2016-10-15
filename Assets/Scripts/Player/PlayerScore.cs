using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScore : MonoBehaviour {

    public int score;
    public int highScore;
    GameObject _scoreText;
    GameObject _highScoreText;
    public Text scoreText;
    public Text highScoreText;

	// Use this for initialization
	void Start () {
        highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreText = GameObject.Find("HighScoreText");
        highScoreText = _highScoreText.GetComponent<Text>();
        _scoreText = GameObject.Find("ScoreText");
        scoreText = _scoreText.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        if(Input.GetKeyDown("r"))
        {
             highScore = 0;
            PlayerPrefs.SetInt("HighScore", highScore);            
        }

        PlayerPrefs.SetInt("Score", score);
            
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        scoreText.text = "Score: " + score;
	}
}
