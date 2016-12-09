using UnityEngine;
using System.Collections;

public class ShipUnlocking : MonoBehaviour
{
    public string shipName;
    public int price;
    public static int realPrice;
    public bool unlocked;
    public GameObject selectButton;
    public GameObject unlockButton;
    public GameObject lockedPanel;


	void Start ()
    {
        price = 500000;
        realPrice = price;
        shipName = transform.name;
        if(PlayerPrefs.GetInt(transform.name) == 1)
            unlocked = true;
    }

    public void ShipUnlocked()
    {
        if (PlayerPrefs.GetInt(transform.name) == 1)
            unlocked = true;
    }

    void Update()
    {
        if (unlocked)
        {
            selectButton.SetActive(true);
            unlockButton.SetActive(false);
            lockedPanel.SetActive(false);
        }
        else if (!unlocked)
        {
            selectButton.SetActive(false);
            unlockButton.SetActive(true);
            lockedPanel.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.R) && DevMode.devMove)
        {
            print("All ships reset");
            PlayerPrefs.SetInt(transform.name, 0);
        }
    }
}