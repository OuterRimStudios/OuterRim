using UnityEngine;
using System.Collections;

public class ShipUnlocking : MonoBehaviour
{

    public string shipName;
    public bool unlocked;
    public GameObject playButton;
    public GameObject lockedButton;
	void Start ()
    {
        shipName = transform.name;
        if (PlayerPrefs.GetInt(shipName) == 1)
        {
            unlocked = true;
        }
	}

    void Update()
    {
        //if (unlocked)
        //{
        //    playButton.SetActive(true);
        //    lockedButton.SetActive(false);
        //}
        //else if (!unlocked)
        //{
        //    playButton.SetActive(false);
        //    lockedButton.SetActive(true);
        //}
    }
}
