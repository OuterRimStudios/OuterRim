using UnityEngine;
using System.Collections;

public class UnlockShip : MonoBehaviour
{
    public GameObject unlockButton;
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
        if(PlayerPrefs.GetInt("Currency") > ShipUnlocking.realPrice)
        {
            price = ShipUnlocking.realPrice;
            myCurrency = PlayerPrefs.GetInt("Currency");
            newCurrency = myCurrency - price;
            PlayerPrefs.SetInt("Currency", newCurrency);
            unlock.UpdatePoints();
            ChooseShipTracker.currentUnlockedShip.GetComponent<ShipUnlocking>().ShipUnlocked();
            ShipUnlockManager.UnlockShip(ChooseShipTracker.currentUnlockedShip);
        }
    }
}
