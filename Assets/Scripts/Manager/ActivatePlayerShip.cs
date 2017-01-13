using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActivatePlayerShip : MonoBehaviour {

    public bool debugMode;
    public List<GameObject> shipPrefabs;
    public GameObject player;
    
    void Start()
    {
        if (!debugMode)
        {
            if (PlayerPrefs.GetString("Ship") == "")
            {
                player = Instantiate(shipPrefabs[0], Vector3.zero, Quaternion.identity) as GameObject;
                player.name = "Player";
                player.tag = "Player";
            }
            else
            {
                for (int i = 0; i < shipPrefabs.Count; i++)
                {

                    if (shipPrefabs[i].name == PlayerPrefs.GetString("Ship"))
                    {
                        player = Instantiate(shipPrefabs[i], Vector3.zero, Quaternion.identity) as GameObject;
                        player.name = "Player";
                        player.tag = "Player";
                    }
                }
            }
        }
    }
}
