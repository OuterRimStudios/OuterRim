﻿using UnityEngine;
using System.Collections;

public class EnemyState : MonoBehaviour {

    public GameObject lockOn;
    public bool isTarget;
    GameObject player;
    FireMissile fireMissile;
    bool canBeTarget;
    GameObject arrow;
    ObjectPooling arrowPool;

    void Start ()
    {
        player = GameObject.Find("Player");
        arrowPool = GameObject.FindGameObjectWithTag("ArrowPool").GetComponent<ObjectPooling>();
        fireMissile =GameObject.Find("MissileNozzle").GetComponent<FireMissile>();
        canBeTarget = true;
       // arrow = arrowPool.GetPooledObject();
        foreach (GameObject arrows in arrowPool.pooledObjects)
        {
            arrows.SetActive(false);
        }
    }

    void OnEnable()
    {
        isTarget = false;
    }
	
	void Update ()
    {
        Vector3 v3Pos = Camera.main.WorldToViewportPoint(transform.position);
        bool onScreen = v3Pos.z > 0 && v3Pos.x > 0 && v3Pos.x < 1 && v3Pos.y > 0 && v3Pos.y < 1;

        if (!onScreen)
            PositionArrow(new Vector3(v3Pos.x, v3Pos.y, v3Pos.z));
        else if (onScreen && arrow != null)
            arrow.SetActive(false);

        //sets laser target
        if (transform.position.z - player.transform.position.z < 20000 &&
            transform.position.z - player.transform.position.z > 100 &&
            transform.position.y - player.transform.position.y < transform.position.z * .1f &&
            transform.position.y - player.transform.position.y > -transform.position.z * .1f &&
            transform.position.x - player.transform.position.x < transform.position.z * .1f &&
            transform.position.x - player.transform.position.x > -transform.position.z * .1f)
        {
            player.GetComponent<AimAssist>().FoundTarget(gameObject);
        }

        //sets missile target
        if ( transform.position.z - player.transform.position.z < 8000 &&
            transform.position.z - player.transform.position.z > 100 &&
            transform.position.y - player.transform.position.y < transform.position.z * .25f &&
            transform.position.y - player.transform.position.y > -transform.position.z * .25f &&
            transform.position.x - player.transform.position.x < transform.position.z * .25f &&
            transform.position.x - player.transform.position.x > -transform.position.z * .25f)
        {
            if (!fireMissile.targetsInRange.Contains(gameObject))
            {
                fireMissile.targetsInRange.Add(gameObject);
            }
        }
        else
        {
            if(fireMissile.targetsInRange.Contains(gameObject))
            {
                fireMissile.targetsInRange.Remove(gameObject);
            }
        }

	    if(isTarget)
        {
            lockOn.SetActive(true);
            fireMissile.hasTarget = true;
        }
        else
        {
            lockOn.SetActive(false);
        }
	}

    void PositionArrow(Vector3 _v3Pos)
    {
        if(arrow == null)
        arrow = arrowPool.GetPooledObject();

        _v3Pos.x -= 0.5f;
        _v3Pos.y -= 0.5f;
        _v3Pos.z = 0;
        arrow.SetActive(true);
        float fAngle = Mathf.Atan2(_v3Pos.x, _v3Pos.y);
        transform.localEulerAngles = new Vector3(0.0f, 0.0f, -fAngle * Mathf.Rad2Deg);

        _v3Pos.x = 0.5f * Mathf.Sin(fAngle) + 0.5f;
        _v3Pos.y = 0.5f * Mathf.Cos(fAngle) + 0.4999f;
        _v3Pos.z = Camera.main.nearClipPlane + 0.01f;
        arrow.transform.position = Camera.main.ViewportToWorldPoint(_v3Pos);
    }
}
