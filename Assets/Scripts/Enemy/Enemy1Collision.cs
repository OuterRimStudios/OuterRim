﻿using UnityEngine;
using System.Collections;

public class Enemy1Collision : MonoBehaviour
{
    public GameObject ship;
    public GameObject explosion;
    public GameObject explosionSound;
    public GameObject meteorExplosionPrefab;
    public GameObject player;

    public int laserScore;
    public int missileScore;
    public int baseHealth;
    public int currentHealth;

    PlayerScore _playerScore;
    AchievementManager achievementManager;
    PublicVariableHandler publicVariableHandler;
    GameObject gameManager;
	GameObject hitEffect;
    PlayerCollision playerCollision;
    FireMissile fireMissile;

    void Awake()
    {
        player = GameObject.Find("Player");
        _playerScore = player.GetComponent<PlayerScore>();
        gameManager = GameObject.Find("GameManager");
        publicVariableHandler = gameManager.GetComponent<PublicVariableHandler>();
        achievementManager = gameManager.GetComponent<AchievementManager>();
        hitEffect = publicVariableHandler.hitEffect;
        fireMissile = GameObject.Find("MissileNozzle").GetComponent<FireMissile>();
    }

    void Start()
    {
  //      player = GameObject.Find("Player");
  //      _playerScore = player.GetComponent<PlayerScore>();
  //      gameManager = GameObject.Find("GameManager");
  //      publicVariableHandler = gameManager.GetComponent<PublicVariableHandler>();
  //      achievementManager = gameManager.GetComponent<AchievementManager>();
		//hitEffect = publicVariableHandler.hitEffect;
  //      fireMissile = GameObject.Find("MissileNozzle").GetComponent<FireMissile>();
        //switch (transform.name)
        //{
        //    case "Enemy 1":
        //        laserScore = publicVariableHandler.enemy1LaserScore;
        //        missileScore = publicVariableHandler.enemy1MissileScore;
        //        baseHealth = publicVariableHandler.enemy1BaseHealth;
        //        break;
        //    case "Enemy 2":
        //        laserScore = publicVariableHandler.enemy2LaserScore;
        //        missileScore = publicVariableHandler.enemy2MissileScore;
        //        baseHealth = publicVariableHandler.enemy2BaseHealth;
        //        break;
        //    case "Enemy 3":
        //        laserScore = publicVariableHandler.enemy3LaserScore;
        //        missileScore = publicVariableHandler.enemy3MissileScore;
        //        baseHealth = publicVariableHandler.enemy3BaseHealth;
        //        break;
        //    case "Enemy 4":
        //        laserScore = publicVariableHandler.enemy4LaserScore;
        //        missileScore = publicVariableHandler.enemy4MissileScore;
        //        baseHealth = publicVariableHandler.enemy4BaseHealth;
        //        break;
        //    case "Enemy 5":
        //        laserScore = publicVariableHandler.enemy5LaserScore;
        //        baseHealth = publicVariableHandler.enemy5BaseHealth;
        //        break;
        //}
        //currentHealth = baseHealth;
    }

    public void OnSpawned()
    {
        if (transform.tag == "Enemy")
        {
            switch (transform.name)
            {
                case "Enemy 01":
                    laserScore = publicVariableHandler.enemy1LaserScore;
                    missileScore = publicVariableHandler.enemy1MissileScore;
                    baseHealth = publicVariableHandler.enemy1BaseHealth;
                    break;
                case "Enemy 02":
                    laserScore = publicVariableHandler.enemy2LaserScore;
                    missileScore = publicVariableHandler.enemy2MissileScore;
                    baseHealth = publicVariableHandler.enemy2BaseHealth;
                    break;
                case "Enemy 03":
                    laserScore = publicVariableHandler.enemy3LaserScore;
                    missileScore = publicVariableHandler.enemy3MissileScore;
                    baseHealth = publicVariableHandler.enemy3BaseHealth;
                    break;
                case "Enemy 04":
                    laserScore = publicVariableHandler.enemy4LaserScore;
                    missileScore = publicVariableHandler.enemy4MissileScore;
                    baseHealth = publicVariableHandler.enemy4BaseHealth;
                    break;
                case "Enemy 05":
                    laserScore = publicVariableHandler.enemy5LaserScore;
                    missileScore = publicVariableHandler.enemy5MissileScore;
                    baseHealth = publicVariableHandler.enemy5BaseHealth;
                    break;
                case "Enemy 06":
                    laserScore = publicVariableHandler.enemy6LaserScore;
                    missileScore = publicVariableHandler.enemy6MissileScore;
                    baseHealth = publicVariableHandler.enemy6BaseHealth;
                    break;
                case "Enemy 07":
                    laserScore = publicVariableHandler.enemy7LaserScore;
                    missileScore = publicVariableHandler.enemy7MissileScore;
                    baseHealth = publicVariableHandler.enemy7BaseHealth;
                    break;
                case "Enemy 08":
                    laserScore = publicVariableHandler.enemy8LaserScore;
                    missileScore = publicVariableHandler.enemy8MissileScore;
                    baseHealth = publicVariableHandler.enemy8BaseHealth;
                    break;
                case "Enemy 09":
                    laserScore = publicVariableHandler.enemy9LaserScore;
                    missileScore = publicVariableHandler.enemy9MissileScore;
                    baseHealth = publicVariableHandler.enemy9BaseHealth;
                    break;
                case "Enemy 10":
                    laserScore = publicVariableHandler.enemy10LaserScore;
                    missileScore = publicVariableHandler.enemy10MissileScore;
                    baseHealth = publicVariableHandler.enemy10BaseHealth;
                    break;
                case "Enemy 11":
                    laserScore = publicVariableHandler.enemy11LaserScore;
                    missileScore = publicVariableHandler.enemy11MissileScore;
                    baseHealth = publicVariableHandler.enemy11BaseHealth;
                    break;
                case "Enemy 12":
                    laserScore = publicVariableHandler.enemy12LaserScore;
                    missileScore = publicVariableHandler.enemy12MissileScore;
                    baseHealth = publicVariableHandler.enemy12BaseHealth;
                    break;
            }
        }
        else if (transform.tag == "Carrier")
        {
            laserScore = publicVariableHandler.carrierScore;
            baseHealth = publicVariableHandler.carrierBaseHealth;
        }

        currentHealth = baseHealth;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Laser")
        {
            Instantiate(hitEffect, col.transform.position, col.transform.rotation);
            //CreateHitEffect(col.gameObject);
            col.gameObject.SetActive(false);
            TookDamage();
        }
        else if (col.gameObject.tag == "Missile")
        {
            fireMissile.hasTarget = false;
            WasDestroyed();
            Destroy(col.gameObject);
        }
        if (transform.tag != "Carrier")
        {
            if (col.gameObject.tag == "Meteor")
            {
                Instantiate(meteorExplosionPrefab, transform.position, transform.rotation);
                col.gameObject.SetActive(false);
                WasDestroyed();
            }
        }
    }

    public void TookDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            WasDestroyed();
        }
    }

    public void WasDestroyed()
    {
        fireMissile.targetsInRange.Remove(gameObject);
        if(fireMissile.target == gameObject)
        {
            fireMissile.hasTarget = false;
        }
        _playerScore.score += laserScore;
        if (gameObject.tag != "Carrier")
        {
            PlayerCollision.fightersDestroyed++;
            gameManager.GetComponent<WaveManager>().ShipDestroyed(gameObject);
        }
        else
        {
            PlayerCollision.carriersDestroyed++;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Instantiate(explosionSound, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }

    //void CreateHitEffect(GameObject other)
    //{
    //    GameObject obj = hitEffect.GetPooledObject();

    //    if (obj == null)
    //        return;

    //    obj.transform.position = other.transform.position;
    //    obj.transform.rotation = other.transform.rotation;
    //    obj.SetActive(true);
    //}
}