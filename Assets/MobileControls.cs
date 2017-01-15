using UnityEngine;
using System.Collections;

public class MobileControls : MonoBehaviour
{
    public static bool shootLaser;
    public static bool shootMissile;

    public void StartLaser()
    {
        shootLaser = true;
    }

    public void StopLaser()
    {
        shootLaser = false;
    }

    public void StartMissile()
    {
        shootMissile = true;
    }

    public void StopMissile()
    {
        shootMissile = false;
    }
}
