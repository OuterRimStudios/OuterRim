﻿using UnityEngine;
using System.Collections;

public class Enemy1Collision : MonoBehaviour {

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

    void Start()
    {
        player = GameObject.Find("Player");
        _playerScore = player.GetComponent<PlayerScore>();
        gameManager = GameObject.Find("GameManager");
        publicVariableHandler = gameManager.GetComponent<PublicVariableHandler>();
        achievementManager = gameManager.GetComponent<AchievementManager>();
		hitEffect = publicVariableHandler.hitEffect;
        fireMissile = GameObject.Find("MissileNozzle").GetComponent<FireMissile>();
        switch (transform.name)
        {
            case "Enemy1":
                laserScore = publicVariableHandler.enemy1LaserScore;
                missileScore = publicVariableHandler.enemy1MissileScore;
                baseHealth = publicVariableHandler.enemy1BaseHealth;
                break;
            case "Enemy2":
                laserScore = publicVariableHandler.enemy2LaserScore;
                missileScore = publicVariableHandler.enemy2MissileScore;
                baseHealth = publicVariableHandler.enemy2BaseHealth;
                break;
            case "Enemy3":
                laserScore = publicVariableHandler.enemy3LaserScore;
                missileScore = publicVariableHandler.enemy3MissileScore;
                baseHealth = publicVariableHandler.enemy3BaseHealth;
                break;
            case "Enemy4":
                laserScore = publicVariableHandler.enemy4LaserScore;
                missileScore = publicVariableHandler.enemy4MissileScore;
                baseHealth = publicVariableHandler.enemy4BaseHealth;
                break;
            case "Enemy5":
                laserScore = publicVariableHandler.enemy5LaserScore;
                baseHealth = publicVariableHandler.enemy5BaseHealth;
                break;
        }
        currentHealth = baseHealth;
    }

    public void OnSpawned()
    {
        currentHealth = baseHealth;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Laser")
        {
            Instantiate(hitEffect, col.transform.position, col.transform.rotation);
            col.gameObject.SetActive(false);
            TookDamage();
        }
        else if (col.gameObject.tag == "Missile" && transform.name != "Enemy5")
        {
            fireMissile.hasTarget = false;
            WasDestroyed();
            Destroy(col.gameObject);
            //col.gameObject.SetActive(false);
        }
        if (transform.name != "Enemy5")
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
       // achievementManager.EnemyHit();
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
        if(gameObject.tag != "Carrier")
            gameManager.GetComponent<WaveManager>().ShipDestroyed(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
        Instantiate(explosionSound, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
}