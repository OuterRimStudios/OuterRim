using UnityEngine;
using System.Collections;

public class DevMode : MonoBehaviour
{
    public static bool devMove;
    int checkInputForOn;
    int checkInputForOff;

    void Start()
    {
        devMove = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0) && devMove == false)
        {
            checkInputForOff = 0;
            checkInputForOn++;
            if (checkInputForOn >= 5)
            {
                print("Dev Mode Enabled");
                devMove = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Keypad1) && devMove == true)
        {
            checkInputForOn = 0;
            checkInputForOff++;
            if (checkInputForOff >= 5)
            {
                print("Dev Mode Disabled");
                devMove = false;
            }
        }
    }
}
