﻿using UnityEngine;
using System.Collections;

public class ShipUnlocking : MonoBehaviour
{
    public string shipName;
    public int price;
    public static int realPrice;
    public bool unlocked;
    public GameObject selectButton;
    public GameObject unlockButton;


	void Start ()
    {
        price = 100000;
        realPrice = price;
        shipName = transform.name;
        if(PlayerPrefs.GetInt(transform.name) == 1)
            unlocked = true;
    }

    public void ShipUnlocked()
    {
    }

    void Update()
    {
        if (unlocked)
        {
            selectButton.SetActive(true);
            unlockButton.SetActive(false);
        }
        else if (!unlocked)
        {
            selectButton.SetActive(false);
            unlockButton.SetActive(true);
        }
    }
}