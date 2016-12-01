using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Unlock : MonoBehaviour {

    public GameObject confirmationWindow;
    public GameObject confirmButton;
    public Text priceText;
    public Text currencryText;
    public static bool unlocking;

    void Update()
    {
        if (Input.GetButtonDown("Fire5") || Input.GetKeyDown(KeyCode.E))
        {
            unlocking = true;
            Purchase();
        }
    }
    public void Purchase()
    {
        confirmationWindow.SetActive(true);
        EventSystem.current.SetSelectedGameObject(confirmButton);
        priceText.text = "Costs: " + ShipUnlocking.realPrice;
        currencryText.text = "Points: " + PlayerPrefs.GetInt("Currency");
    }
}