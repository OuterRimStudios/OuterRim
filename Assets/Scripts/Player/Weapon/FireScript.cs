using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

    public GameObject laser;
	float baseFireFreq;
    float fireFreq;

    float lastShot;
    float laserTimer;

    ObjectPooling laserPool;
    GameObject gameManager;
    AchievementManager achievementManager;
    PublicVariableHandler publicVariableHandler;
    LaserSound laserSound;

    GameObject player;

    AudioClip noLevelSound;
    AudioClip level1Sound;
    AudioClip level2Sound;
    AudioClip level3Sound;
    float laserActiveTime;
    float dualLaserActiveTime;
    [HideInInspector]
    public Transform target;
    bool laserPowerActive;
    bool dualLaserActive;
    void Start()
    {
        laserPool = GameObject.Find("PlayerLasers").GetComponent<ObjectPooling>();
        gameManager = GameObject.Find("GameManager");
        publicVariableHandler = gameManager. GetComponent<PublicVariableHandler>();
        achievementManager = gameManager.GetComponent<AchievementManager>();
        player = GameObject.Find("Player");
        baseFireFreq = publicVariableHandler.playerShootingFrequency;
		fireFreq = baseFireFreq;
        laserActiveTime = publicVariableHandler.laserPickUpActiveTime;
        dualLaserActiveTime = publicVariableHandler.dualLaserPickUpActiveTime;
        if (transform.tag == "PodLeft")
			fireFreq = .5f;
		else if (transform.tag == "PodRight")
			fireFreq = .5f;

        noLevelSound = publicVariableHandler.laserNoLevelSound;
        level1Sound = publicVariableHandler.laserLevel1Sound;
        level2Sound = publicVariableHandler.laserLevel2Sound;
        level3Sound = publicVariableHandler.laserLevel3Sound;

        if (GetComponent<LaserSound>() != null)
        {
            laserSound = GetComponent<LaserSound>();
        }
    }

    void Update()
    {
        if ((Input.GetAxis("Fire1") > 0) && Time.time > lastShot + fireFreq)
        {
            if (target == null || target.tag != "Enemy")
                Fire();
            else
            {
                transform.LookAt(target);
                Fire();
                target = null;
                transform.rotation = Quaternion.identity;
            }
        }
    }

    void Fire()
    {
        target = null;
        if (laserSound != null)
        {
            laserSound.Shooting();
        }
            lastShot = Time.time;

            GameObject obj = laserPool.GetPooledObject();

            if (obj == null)
            {
                return;
            }
            obj.transform.position = transform.position;
            obj.transform.rotation = transform.rotation;
            obj.SetActive(true);
    }      

    public void LaserUpgrade()
    {
        if(!laserPowerActive)
        {
            laserPowerActive = true;
            fireFreq = fireFreq / 2;
            // if (laserSound)
            // laserSound.LevelChange(level2Sound);

            StartCoroutine(LaserPickUpActive());
        }
    }

    public void DualLaserUpgrade()
    {
        if (!dualLaserActive)
        {
            dualLaserActive = true;
            foreach (GameObject go in player.GetComponent<StoreVariables>().upgradeWeapons)
            {
                go.SetActive(true);
            }
            //  if (laserSound)
            // laserSound.LevelChange(level3Sound);
            StartCoroutine(DualLaserPickUpActive());
        }
    }

    IEnumerator LaserPickUpActive()
    {
        yield return new WaitForSeconds(laserActiveTime);
        //  if (laserSound)
        //  laserSound.LevelChange(level1Sound);
        fireFreq = fireFreq * 2;
        laserPowerActive = false;
    }

    IEnumerator DualLaserPickUpActive()
    {
        yield return new WaitForSeconds(dualLaserActiveTime);
        //  if (laserSound)
        //  laserSound.LevelChange(level1Sound);
        foreach (GameObject go in player.GetComponent<StoreVariables>().upgradeWeapons)
        {
            go.SetActive(false);
        }
       // if (laserSound)
         //   laserSound.LevelChange(level2Sound);

        dualLaserActive = false;
    }
}
