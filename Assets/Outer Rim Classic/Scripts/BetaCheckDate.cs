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
        playableDates[0] = "12/22/2016";
        playableDates[1] = "12/23/2016";
        playableDates[2] = "12/24/2016";
        playableDates[3] = "12/25/2016";
        playableDates[4] = "12/26/2016";
        playableDates[5] = "12/27/2016";
        playableDates[6] = "12/28/2016";
        playableDates[7] = "12/29/2016";

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
