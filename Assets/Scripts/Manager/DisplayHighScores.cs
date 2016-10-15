using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayHighScores : MonoBehaviour {

    public Text[] highScoreFields;
    HighScores highScoresManager;

    void Start()
    {
        for (int i = 0; i < highScoreFields.Length; i++)
        {
            highScoreFields[i].text = i + 1 + ". Fetching...";
        }


        highScoresManager = GetComponent<HighScores>();
        StartCoroutine("RefreshHighScores");
    }

    public void OnHighScoresDownloaded(HighScore[] highScoreList)
    {
        for (int i = 0; i < highScoreFields.Length; i++)
        {
            highScoreFields[i].text = i + 1 + ". ";
            if (i < highScoreList.Length)
            {
                highScoreFields[i].text += highScoreList[i].username + " - " + highScoreList[i].score;
            }
        }
    }

    IEnumerator RefreshHighScores()
    {
        while (true)
        {
            highScoresManager.DownloadHighScores();
            yield return new WaitForSeconds(30);
        }
    }
}
