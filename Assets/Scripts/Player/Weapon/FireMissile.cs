using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FireMissile : MonoBehaviour
{
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
    bool hasTarget;

    PublicVariableHandler publicVariableHandler;

    // Use this for initialization
    void Start()
    {
        hasTarget = false;
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        lightningGun = GameObject.Find("LightningGun");
        lightningGun.SetActive(false);
        publicVariableHandler = gameManager.GetComponent<PublicVariableHandler>();
        missile = player.GetComponent<StoreVariables>().missileColor;
        lightningGunDuration = publicVariableHandler.lightningGunDuration;
        player.GetComponent<StoreVariables>().lightningGun.GetComponent<ArcReactorDemoGunController>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire2") > 0)
        {
            FindEnemy();
        }
        if (((Input.GetAxis("Fire2") > 0) && Time.time > (lastShot + missileCooldown) && hasTarget && missileCount > 0))   // || (Input.GetAxis("Secondary")) != 0)
        {
            Missile();
        }
    }

    void Missile()
    {
        lastShot = Time.time;
        Instantiate(missile, transform.position, transform.rotation);
        missileCount--;
        if (missileCount < missileMax && !(missileCount >= missileMax))
        {
            StartCoroutine(MissileRecharge(missileRechargeLength));
        }
    }

    void FindEnemy()
    {
        target = GameObject.FindGameObjectWithTag("Enemy");
        if (target == null)
        {
            hasTarget = false;
        }
        else if (target.activeInHierarchy)
        {
            target.GetComponent<EnemyState>().isTarget = true;
            hasTarget = true;
        }
        else if (!target.activeInHierarchy)
        {
            hasTarget = false;
        }
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
            StartCoroutine(LightningGunActive());
        }
        else if (!levelUp)
        {
        }
    }

    IEnumerator LightningGunActive()
    {
        lightningGun.SetActive(true);
        player.GetComponent<StoreVariables>().lightningGun.GetComponent<ArcReactorDemoGunController>().enabled = true;
        yield return new WaitForSeconds(lightningGunDuration);
        player.GetComponent<StoreVariables>().lightningGun.GetComponent<ArcReactorDemoGunController>().enabled = false;
        gameManager.GetComponent<PickUpManager>().LoseMissileLevel();
        lightningGun.SetActive(false);
    }
}
