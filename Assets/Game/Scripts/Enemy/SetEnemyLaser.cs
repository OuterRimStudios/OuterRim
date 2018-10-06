using UnityEngine;
using System.Collections;

public class SetEnemyLaser : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Enemy");
        GetComponent<ObjectPooling>().pooledObject[0] = player.GetComponent<StoreVariables>().laserColor;
    }
}
