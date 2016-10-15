using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour
{
    public Transform target;
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(target);
        //transform.localRotation = Quaternion.Euler(0, Mathf.Clamp(transform.rotation.y,-25f,25f),0);
        //transform.localRotation = new Quaternion(Mathf.Clamp(transform.rotation.x, transform.rotation.x, transform.rotation.x), 0, Mathf.Clamp(transform.rotation.z, transform.rotation.z, transform.rotation.z), 0f);
    }
}
