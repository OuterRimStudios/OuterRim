using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipUnlocking : MonoBehaviour
{

    public string shipName;
    public bool unlocked;
    public GameObject playButton;
    public GameObject lockedButton;
    public GameObject confirmationWindow;

    public Text priceText;
    public Text yourCurrency;
    int price;
    int currency;

    // Use this for initialization
    void Start()
    {
        shipName = transform.name;
        if (PlayerPrefs.GetInt(shipName) == 1)
        {
            unlocked = true;
        }

        PlayerPrefs.SetInt("Price", 1000);
        PlayerPrefs.SetInt("Currency", 2000);
        price = PlayerPrefs.GetInt("Price");
        currency = PlayerPrefs.GetInt("Currency");

    }

    public void Unlock()
    {
        confirmationWindow.SetActive(true);
        priceText.text = "Costs: " + price;
        yourCurrency.text = "Points: " + currency;
    }
    public void Yes()
    {
        if (currency >= price)
        {
            currency = currency - price;
            yourCurrency.text = "Your Currency: " + currency;
        }
    }
    public void No()
    {

    }
    void Update()
    {
        if (unlocked)
        {
            playButton.SetActive(true);
            lockedButton.SetActive(false);
        }
        else if (!unlocked)
        {
            playButton.SetActive(false);
            lockedButton.SetActive(true);
        }
    }
}
