using UnityEngine;
using System.Collections;

public class ShipUnlocking : MonoBehaviour
{
    public string shipName;
    public int price;
    public static int realPrice;
    public bool unlocked;
    public GameObject playButton;
    public GameObject unlockButton;


	void Start ()
    {
        price = 100000;
        realPrice = price;
        shipName = transform.name;

	}

    public void ShipUnlocked()
    {
        unlocked = true;
    }

    void Update()
    {
        if (unlocked)
        {
            playButton.SetActive(true);
            unlockButton.SetActive(false);
        }
        else if (!unlocked)
        {
            playButton.SetActive(false);
            unlockButton.SetActive(true);
        }
    }
}