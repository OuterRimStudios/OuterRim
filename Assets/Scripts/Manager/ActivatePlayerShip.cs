using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivatePlayerShip : MonoBehaviour {

    public bool debugMode;
    public List<GameObject> shipPrefabs;
    public GameObject player;

	// Use this for initialization
	void Start ()
    {
        Object[] subListObjects = Resources.LoadAll("ShipTypes", typeof(GameObject));

        foreach (GameObject go in subListObjects)
        {
            shipPrefabs.Add(go);
        }

        if (!debugMode)
        {
            if (PlayerPrefs.GetString("Ship") == "")
            {
                player = Instantiate(shipPrefabs[0], Vector3.zero, Quaternion.identity) as GameObject;
                player.name = "Player";
            }
            else
            {
                for (int i = 0; i < shipPrefabs.Count; i++)
                {
                
                    if (shipPrefabs[i].name == PlayerPrefs.GetString("Ship"))
                    {
                        player = Instantiate(shipPrefabs[i], Vector3.zero, Quaternion.identity) as GameObject;
                        player.name = "Player";
                    }
                }
            }
        }
        else
        {
            //do nothing
        }
	}

    // Update is called once per frame
    void Update()
    {
	
	}
}
