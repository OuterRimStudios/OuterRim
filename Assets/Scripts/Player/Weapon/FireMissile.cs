using UnityEngine;
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

    bool isLevel3;
    
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
        if (((Input.GetAxis("Fire2") > 0) && Time.time > (lastShot + missileCooldown) && hasTarget && missileCount > 0) && target != null && doneShooting == true)   // || (Input.GetAxis("Secondary")) != 0)
        {
            doneShooting = false;
            target.GetComponent<EnemyState>().isTarget = false;
            if (isLevel3)
                Level3Missile();
            else
            Missile();
        }
    }

    void Level3Missile()
    {
        foreach (GameObject enemy in waveManager.activeEnemies)
        {
            GameObject clone = Instantiate(missile, transform.position, transform.rotation) as GameObject;
            clone.GetComponent<MissileMovement>().target = enemy;
            enemy.GetComponent<EnemyState>().isTarget = true;
        }
        isLevel3 = false;
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
       target = targetsInRange[Random.Range(0, targetsInRange.Count)];
       target.GetComponent<EnemyState>().isTarget = true;
    }

    IEnumerator MissileRecharge(float _missileRechargeLength)
    {
        recharge = _missileRechargeLength;
        yield return new WaitForSeconds(recharge);
        missileCount++;
    }

    public void MissileLevel1(bool levelUp)
    {
        if (levelUp)
        {
            missileRechargeLength = missileRechargeLength / 2;
            newRecharge = recharge;
            missileCooldown = missileCooldown / 3;
            newMissileCooldown = missileCooldown;
        }
        else if (!levelUp)
        {
            missileRechargeLength = missileRechargeLength * 2;
            missileCooldown = missileCooldown * 3;
        }
    }

    public void MissileLevel2(bool levelUp)
    {
        if (levelUp)
        {
            missileRechargeLength = missileRechargeLength / 2;
            missileCooldown = 0;
        }
        else if (!levelUp)
        {
            missileRechargeLength = newRecharge;
            missileCooldown = newMissileCooldown;
        }
    }

    public void MissileLevel3(bool levelUp)
    {
        if (levelUp)
        {
            isLevel3 = true;
        }
        else if (!levelUp)
        {
            isLevel3 = false;
        }
    }
}
