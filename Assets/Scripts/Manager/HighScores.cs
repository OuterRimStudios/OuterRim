using UnityEngine;
using System.Collections;

public class HighScores : MonoBehaviour {

    const string privateCode = "eOojnfxPU0SJXAM7RhhC-gHxGAVhfnKU-UtZfTEAjThw";
    const string publicCode = "57fd237f8af60313d47e19c5";
    const string webURL = "http://dreamlo.com/lb/";

    DisplayHighScores highScoreDisplay;
    public HighScore[] highScoresList;
    static HighScores instance;

    void Awake()
    {
        highScoreDisplay = GetComponent<DisplayHighScores>();
        instance = this;
    }

    public static void AddNewHighScore(string username, int score)
    {
        instance.StartCoroutine(instance.UploadNewHighscore(username, score));
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            print("Upload Successful");
            DownloadHighScores();
        }
        else
        {
            print("Error uploading: " + www.error);
        }
    }

    public void DownloadHighScores()
    {
        StartCoroutine("DownloadHighScoresFromDatabase");
    }

    IEnumerator DownloadHighScoresFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighScores(www.text);
            highScoreDisplay.OnHighScoresDownloaded(highScoresList);
        }
        else
        {
            print("Error Downloading: " + www.error);
        }
    }

    void FormatHighScores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highScoresList = new HighScore[entries.Length];

        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highScoresList[i] = new HighScore(username, score);
            //print(highScoresList[i].username + ": " + highScoresList[i].score);
        }
    }

}

public struct HighScore
{
    public string username;
    public int score;

    public HighScore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }

}