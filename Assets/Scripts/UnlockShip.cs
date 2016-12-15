using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using InControl;

public class UnlockShip : MonoBehaviour
{
    public GameObject confirmationWindow;
    public Text priceText;
    public Text currencyText;
    Unlock unlock;
    int price;
    int myCurrency;
    int newCurrency;
    InputDevice inputDevice;

    void Update()
    {
        inputDevice = InputManager.ActiveDevice;

        if(inputDevice.Action1.WasPressed || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return))
        {
            Unlock.unlocking = false;
            ConfirmPurchase();
        }

        if (inputDevice.Action2.WasReleased || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Backspace))
        {
            Unlock.unlocking = false;
            confirmationWindow.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.R) && DevMode.devMove)
        {
            print("All currency reset");
            PlayerPrefs.SetInt("Currency", 0);
        }
    }

    public void ConfirmPurchase()
    {
        if(PlayerPrefs.GetInt("Currency") > ShipUnlocking.realPrice)
        {
            price = ShipUnlocking.realPrice;
            myCurrency = PlayerPrefs.GetInt("Currency");
            newCurrency = myCurrency - price;
            PlayerPrefs.SetInt("Currency", newCurrency);            
            ShipUnlockManager.UnlockShip(ChooseShipTracker.currentUnlockedShip);
            ChooseShipTracker.currentUnlockedShip.GetComponent<ShipUnlocking>().ShipUnlocked();
            UpdatePoints();
        }
    }

    public void UpdatePoints()
    {
        currencyText.text = "Points: " + PlayerPrefs.GetInt("Currency");
        confirmationWindow.SetActive(false);
    }
}
