using UnityEngine;
using System.Collections;

public class ShipUnlockManager : MonoBehaviour
{
    public static void UnlockShip(GameObject ship)
    {
        PlayerPrefs.SetInt(ship.transform.name, 1);
    }
}
