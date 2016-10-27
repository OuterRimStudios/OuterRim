using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControllerDetection : MonoBehaviour {

    public static bool xBox;
    public static bool ps;
    List<string> joysticks;

    // Update is called once per frame
	void Update () {
        joysticks = new List<string>();

        for (int i = 0; i < Input.GetJoystickNames().GetLength(0); i++)
        {
            joysticks.Add(Input.GetJoystickNames()[i]);
        }

        if (joysticks.Contains("Wireless Controller"))
        {
            xBox = false;
            ps = true;
        }
        else if (joysticks.Contains("Controller (XBOX 360 For Windows)") || joysticks.Contains("Controller (Xbox One For Windows)"))
        {
            xBox = true;
            ps = false;
        }
        else
        {
            xBox = false;
            ps = false;
        }
	}
}
