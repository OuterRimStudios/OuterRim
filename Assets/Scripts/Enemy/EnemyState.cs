using UnityEngine;
using System.Collections;

public class EnemyState : MonoBehaviour {

    public GameObject lockOn;
    public bool isTarget;

	// Use this for initialization
	void Start () {
        
	}

    void OnEnable()
    {
        isTarget = false;
    }
	
	// Update is called once per frame
	void Update () {
	    if(isTarget)
        {
            lockOn.SetActive(true);
        }
        else
        {
            lockOn.SetActive(false);
        }
	}
}
