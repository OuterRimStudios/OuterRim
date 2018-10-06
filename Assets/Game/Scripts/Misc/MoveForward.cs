using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour 
{
	public float minSpeed;
    public float maxSpeed;
    float speed;
    
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }
	void FixedUpdate ()
	{
		transform.position += Vector3.back * Time.deltaTime * speed;
	}

}
