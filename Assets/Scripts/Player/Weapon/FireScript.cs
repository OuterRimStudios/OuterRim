﻿using UnityEngine;
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

    [HideInInspector]
    public Transform target;

    void Start()
    {
        laserPool = GameObject.Find("PlayerLasers").GetComponent<ObjectPooling>();
        gameManager = GameObject.Find("GameManager");
        publicVariableHandler = gameManager. GetComponent<PublicVariableHandler>();
        achievementManager = gameManager.GetComponent<AchievementManager>();
        player = GameObject.Find("Player");
        baseFireFreq = publicVariableHandler.playerShootingFrequency;
		fireFreq = baseFireFreq;

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
        print("No level sound " + noLevelSound.name);
        print("Level 1 sound " + level1Sound.name);
        print("Level 2 sound " + level2Sound.name);
        print("Level 3 sound " + level3Sound.name);
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
            //achievementManager.LaserShot();
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
    
    public void LaserLevel1(bool levelUp)
    {
        if (levelUp)
        {
            if (laserSound)
                laserSound.LevelChange(level1Sound);
        }
        else if (!levelUp)
        {
            if (laserSound)
                laserSound.LevelChange(noLevelSound);
        }
    }

    public void LaserLevel2(bool levelUp)
    {
        if (levelUp)
        {
            fireFreq = fireFreq / 2;
            if (laserSound)
                laserSound.LevelChange(level2Sound);
        }
        else if (!levelUp)
        {
            fireFreq = fireFreq * 2;
            if (laserSound)
                laserSound.LevelChange(level1Sound);
        }
    }

    public void LaserLevel3(bool levelUp)
    {
        if (levelUp)
        {
            foreach (GameObject go in player.GetComponent<StoreVariables>().upgradeWeapons)
            {
                go.SetActive(true);
            }

            if (laserSound)
                laserSound.LevelChange(level3Sound);
        }
        else if (!levelUp)
        {
              foreach (GameObject go in player.GetComponent<StoreVariables>().upgradeWeapons)
            {
				go.SetActive(false);
            }

            if (laserSound)
                laserSound.LevelChange(level2Sound);
        }
    }
}
