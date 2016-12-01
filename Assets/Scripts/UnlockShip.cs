using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnlockShip : MonoBehaviour
{
    public GameObject confirmationWindow;
    public Text priceText;
    public Text currencyText;
    Unlock unlock;
    int price;
    int myCurrency;
    int newCurrency;

    void Update()
    {
        if(Input.GetButtonDown("Submit"))
        {
            Unlock.unlocking = false;
            ConfirmPurchase();
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Unlock.unlocking = false;
            confirmationWindow.SetActive(false);
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
