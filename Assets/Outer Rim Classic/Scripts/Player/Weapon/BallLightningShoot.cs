using UnityEngine;
using System.Collections;

public class BallLightningShoot : MonoBehaviour 
{
    public float projectileSpeed;
	void Update () 
    {
        transform.position += Vector3.forward * projectileSpeed * Time.deltaTime;
	}
}
