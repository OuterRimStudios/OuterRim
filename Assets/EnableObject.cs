using UnityEngine;
using System.Collections;

public class EnableObject : MonoBehaviour
{
    public GameObject[] objects;
    
	void Start()
    {
	    foreach (GameObject go in objects)
        {
            go.SetActive(true);
        }
	}
}
