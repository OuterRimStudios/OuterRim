using UnityEngine;
using System.Collections;

public class ResetShipUnlocks : MonoBehaviour
{
    ShipWrangler shipWrangler;

    void Start()
    {
        shipWrangler = GetComponent<ShipWrangler>();
    }
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.R) && DevMode.devMove)
        {
            foreach(GameObject go in shipWrangler.ships)
            {
                print("All ships reset");
                PlayerPrefs.SetInt(go.transform.name, 0);
            }
        }
	}
}
