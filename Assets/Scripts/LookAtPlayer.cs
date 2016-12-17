using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour
{
    GameObject player;

	void Start () {
        player = GameObject.Find("Player");
	}
	
	void Update () {
        transform.LookAt(player.transform);
	}
}
