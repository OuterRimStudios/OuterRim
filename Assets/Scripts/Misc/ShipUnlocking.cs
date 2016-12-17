using UnityEngine;
using System.Collections;

public class ShipUnlocking : MonoBehaviour
{
    public string shipName;
    public int price;
    public static int realPrice;
    public static bool choosingColor;
    public bool unlocked;
    public GameObject selectButton;
    public GameObject unlockButton;
    public GameObject colorButton;
    public GameObject lockedPanel;

	void Start ()
    {
        price = 100;
        realPrice = price;
        choosingColor = false;
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
            if (!choosingColor)
                colorButton.SetActive(true);
            else
                colorButton.SetActive(false);
        }
        else if (!unlocked)
        {
            selectButton.SetActive(false);
            unlockButton.SetActive(true);
            colorButton.SetActive(false);
            lockedPanel.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.R) && DevMode.devMove)
        {
            print("All ships reset");
            PlayerPrefs.SetInt(transform.name, 0);
        }
    }
}