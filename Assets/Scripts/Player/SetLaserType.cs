using UnityEngine;
using System.Collections;

public class SetLaserType : MonoBehaviour
{
    GameObject player;

	void Start ()
    {
        player = GameObject.Find("Player");
        GetComponent<ObjectPooling>().pooledObject[0] = player.GetComponent<StoreVariables>().laserColor;
	}
}
