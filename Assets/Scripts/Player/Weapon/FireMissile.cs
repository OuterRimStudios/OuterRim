﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class FireMissile : MonoBehaviour
{
    public List<GameObject> targetsInRange;
    public GameObject missile;
    public GameObject target;
    public GameObject noTarget;

    public float missileRechargeLength;
    public float missileCooldown;
    public float lightningGunDuration;

    public int missileCount;
    public int missileMax;

    GameObject player;
    GameObject gameManager;
    GameObject lightningGun;

    float lastShot;
    float recharge;
    float newRecharge;
    float newMissileCooldown;

    [HideInInspector]
    public bool hasTarget;
    public static bool doneShooting;

    PublicVariableHandler publicVariableHandler;
    WaveManager waveManager;

    bool missileUpgraded;
    
    void Start()
    {
        hasTarget = false;
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        waveManager = gameManager.GetComponent<WaveManager>();
        publicVariableHandler = gameManager.GetComponent<PublicVariableHandler>();
        missile = player.GetComponent<StoreVariables>().missileColor;
        player.GetComponent<StoreVariables>().lightningGun.GetComponent<ArcReactorDemoGunController>().enabled = false;
        doneShooting = true;
    }
    
    void Update()
    {
        if (!hasTarget && targetsInRange.Count >= 1 || target != null && !target.activeInHierarchy && targetsInRange.Count >= 1)
        {
            FindEnemy();
        }
        if (!targetsInRange.Contains(target) && target == null && targetsInRange.Count >= 1)
        {
            FindEnemy();
        }
        if (((Input.GetAxis("Fire2") > 0) && Time.time > (lastShot + missileCooldown) && hasTarget && missileCount > 0) && target != null)   // || (Input.GetAxis("Secondary")) != 0)
        {
            target.transform.parent.GetComponent<EnemyState>().isTarget = false;
            if (missileUpgraded)
                MissileUpgraded();
            else
            Missile();
        }
    }

    void MissileUpgraded()
    {
        foreach (GameObject enemy in waveManager.activeEnemies)
        {
            GameObject clone = Instantiate(missile, transform.position, transform.rotation) as GameObject;
            clone.GetComponent<MissileMovement>().target = enemy;
            enemy.GetComponent<EnemyState>().isTarget = true;
        }
        missileUpgraded = false;
    }
    void Missile()
    {
        lastShot = Time.time;
        GameObject clone = Instantiate(missile, transform.position, transform.rotation) as GameObject;
        clone.GetComponent<MissileMovement>().target = target;
        missileCount--;
        target = null;
        if (missileCount < missileMax && !(missileCount >= missileMax))
        {
            StartCoroutine(MissileRecharge(missileRechargeLength));
        }
    }

    void FindEnemy()
    {
       target = targetsInRange[Random.Range(0, targetsInRange.Count)].transform.FindChild("LookAtPoint").gameObject;
       target.transform.parent.GetComponent<EnemyState>().isTarget = true;
    }

    IEnumerator MissileRecharge(float _missileRechargeLength)
    {
        recharge = _missileRechargeLength;
        yield return new WaitForSeconds(recharge);
        missileCount++;
    }

    public void MissilePickUp()
    {
        missileUpgraded = true;
    }
}
