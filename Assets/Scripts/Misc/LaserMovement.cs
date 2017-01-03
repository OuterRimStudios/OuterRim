using UnityEngine;
using System.Collections;

public class LaserMovement : MonoBehaviour {

    public float laserSpeedMin;
    public float laserSpeedMax;
    public float laserRange;
    float laserSpeed;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        laserSpeed = Random.Range(laserSpeedMin, laserSpeedMax);
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
