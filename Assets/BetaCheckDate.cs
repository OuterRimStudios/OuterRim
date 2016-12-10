using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class BetaCheckDate : MonoBehaviour
{
    string[] playableDates;
    int checkDate;

    void Start()
    {
        string[] playableDates = new string[6];
        playableDates[0] = "12/10/2016";
        playableDates[1] = "12/11/2016";
        playableDates[2] = "12/12/2016";
        playableDates[3] = "12/13/2016";
        playableDates[4] = "12/14/2016";
        playableDates[5] = "12/15/2016";

        foreach (string date in playableDates)
        {
            if (DateTime.Now.ToString().Substring(0, 10) == date)
            {
               //Do Nothing
            }
            else
            {
                checkDate++;
            }
        }

        if(checkDate == playableDates.Length)
        {
            SceneManager.LoadScene("Update");
        }
    }
}
