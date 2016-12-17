using UnityEngine;
using System.Collections;

public class CheckPosition : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        if(transform.position.z - player.transform.position.z < -10000)
        {
            Destroy(gameObject);
            PlanetGenerator.planetActive = false;
        }
    }
}
