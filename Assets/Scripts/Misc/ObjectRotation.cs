using UnityEngine;
using System.Collections;

public class ObjectRotation : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Rotate(transform.up * speed * Time.deltaTime, Space.World);
	}
}
