using UnityEngine;
using System.Collections;

public class LaserLookAt : MonoBehaviour 
{
	public Transform Target;
	public float rotationSpeed;

	private Quaternion lookRotation;
	private Vector3 direction;

	bool done = true;

	void Update()
	{
		direction = (Target.position - transform.position).normalized;
		lookRotation = Quaternion.LookRotation(direction);
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
	}

}
