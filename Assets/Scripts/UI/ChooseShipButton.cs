﻿using UnityEngine;
using System.Collections;

public class ChooseShipButton : MonoBehaviour
{
    public GameObject shipContainer;

    ShipWrangler _shipWrangler;
    bool hasMoved;

	void Start ()
    {
        _shipWrangler = shipContainer.GetComponent<ShipWrangler>();
	}

	void Update ()
    {

    }

    public void NextShip()
    {
        _shipWrangler.NextSelection();
    }

    public void PreviousShip()
    {
        _shipWrangler.PreviousSelection();
    }

    public void Play()
    {
        PlayerPrefs.SetString("Ship", ChooseShipTracker.currentShipName);
        GetComponent<LoadLevel>().LevelLoad();
    }
}
