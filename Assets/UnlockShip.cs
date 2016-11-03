using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnlockShip : MonoBehaviour
{
    public GameObject unlockButton;
    public GameObject confirmationWindow;
    public Text priceText;
    public Text currencryText;
    Unlock unlock;
    int price;
    int myCurrency;
    int newCurrency;

    void Start()
    {
        unlock = unlockButton.GetComponent<Unlock>();
    }

    public void ConfirmPurchase()
    {
        print("It called you IDIOT");
        if(PlayerPrefs.GetInt("Currency") > ShipUnlocking.realPrice)
        {
            price = ShipUnlocking.realPrice;
            myCurrency = PlayerPrefs.GetInt("Currency");
            newCurrency = myCurrency - price;
            PlayerPrefs.SetInt("Currency", newCurrency);
            UpdatePoints();
            ChooseShipTracker.currentUnlockedShip.GetComponent<ShipUnlocking>().ShipUnlocked();
            ShipUnlockManager.UnlockShip(ChooseShipTracker.currentUnlockedShip);
        }
    }
    public void UpdatePoints()
    {
        currencryText.text = "Points: " + PlayerPrefs.GetInt("Currency");
        confirmationWindow.SetActive(false);
    }
}
