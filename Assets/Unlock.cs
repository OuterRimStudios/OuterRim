using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Unlock : MonoBehaviour {

    public GameObject confirmationWindow;
    public Text priceText;
    public Text currencryText;
    int currency;

    void Start()
    {
        currency = PlayerPrefs.GetInt("Currency");
    }

    public void Purchase()
    {
        confirmationWindow.SetActive(true);
        priceText.text = "Costs: " + ShipUnlocking.realPrice;
        currencryText.text = "Points: " + currency;
    }

    public void UpdatePoints()
    {
        currencryText.text = "Points: " + PlayerPrefs.GetInt("Currency");
        confirmationWindow.SetActive(false);
    }
}
