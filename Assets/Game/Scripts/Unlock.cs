using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using InControl;

public class Unlock : MonoBehaviour {

    public GameObject confirmationWindow;
    public GameObject confirmButton;
    public Text priceText;
    public Text currencryText;
    public static bool unlocking;
    InputDevice inputDevice;

    void Update()
    {
        inputDevice = InputManager.ActiveDevice;
        if ( inputDevice.Action4.WasPressed || Input.GetKeyDown(KeyCode.E))
        {
            unlocking = true;
            Purchase();
        }
    }
    public void Purchase()
    {
        confirmationWindow.SetActive(true);
        priceText.text = "Costs: " + ShipUnlocking.realPrice;
        currencryText.text = "Points: " + PlayerPrefs.GetInt("Currency");
    }
}