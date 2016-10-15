using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissileMovement : MonoBehaviour {

    public float missileSpeed;
    public GameObject target;
    GameObject nozzle;
    List<GameObject> possibleTargets;
    GameObject possibleTarget;

    void Start()
    {
        nozzle = GameObject.Find("MissileNozzle");
        target = nozzle.GetComponent<FireMissile>().target;
        StartCoroutine(IncreaseSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        if (target.activeInHierarchy)
        {
            transform.LookAt(target.transform);
            transform.Translate(Vector3.forward * missileSpeed * Time.deltaTime);
        }
        else
        {
            Destroy(this);
        }
    }

    IEnumerator IncreaseSpeed()
    {
        for(int i = 0; i <= 4; i++)
        {
            missileSpeed = missileSpeed * 1.5f;
            yield return new WaitForSeconds(1);
        }
    }
}
