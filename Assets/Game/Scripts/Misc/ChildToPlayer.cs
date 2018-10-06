using UnityEngine;
using System.Collections;

public class ChildToPlayer : MonoBehaviour
{
	void Start ()
    {
        gameObject.transform.parent = GameObject.Find("Player").transform;
        gameObject.transform.position = new Vector3(0, 0, 1000);
	}
}
