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
        string[] playableDates = new string[8];
        playableDates[0] = "12/15/2016";
        playableDates[1] = "12/16/2016";
        playableDates[2] = "12/17/2016";
        playableDates[3] = "12/18/2016";
        playableDates[4] = "12/19/2016";
        playableDates[5] = "12/20/2016";
        playableDates[6] = "12/21/2016";
        playableDates[7] = "12/22/2016";

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
