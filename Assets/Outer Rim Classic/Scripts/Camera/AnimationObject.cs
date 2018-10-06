using UnityEngine;
using System.Collections;

public class AnimationObject : MonoBehaviour {

    //public GameObject player;
    GameObject playerTarget;
    public float objectSpeed;
    public Vector3 objectOffset;

	// Use this for initialization
	void Start () {
        //player = GameObject.Find("Player");
        //playerTarget = GameObject.Find("PlayerTarget");
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(Camera.main.transform.position.x + objectOffset.x, Camera.main.transform.position.y + objectOffset.y, Camera.main.transform.position.z + objectOffset.z), Time.deltaTime * objectSpeed);

    }
}
