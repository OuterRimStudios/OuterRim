using UnityEngine;
using System.Collections;

public class ChooseShipButton : MonoBehaviour {

    public GameObject shipContainer;

    ShipWrangler _shipWrangler;
    bool hasMoved;
	// Use this for initialization
	void Start () {
        _shipWrangler = shipContainer.GetComponent<ShipWrangler>();
	}
	
	// Update is called once per frame
	void Update () {

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
        //    if (_shipWrangler.CurrentShip.GetComponent<ShipUnlocking>().unlocked == true)
        //    {
        PlayerPrefs.SetString("Ship", ChooseShipTracker.currentShipName);
        GetComponent<LoadLevel>().LevelLoad();
       // }
    }
}
