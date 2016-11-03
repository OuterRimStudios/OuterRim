using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Unlock : MonoBehaviour
{
    GameObject currentShip;
	
    void Update()
    {
        currentShip = ChooseShipTracker.currentActiveShip;
        print(currentShip);
    }
	public void Unlocked ()
    {
        currentShip = ChooseShipTracker.currentActiveShip;
        currentShip.GetComponent<ShipUnlocking>().Unlock();
    }
}
