using UnityEngine;
using System.Collections;

public class LaserMovement : MonoBehaviour {

    public float laserSpeed;
    public float laserRange;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, 0, laserSpeed * Time.deltaTime);

        if (transform.position.z > player.transform.position.z + laserRange || transform.position.z < player.transform.position.z - (laserRange / 2))
        {
            gameObject.SetActive(false);
        }
    }
}
