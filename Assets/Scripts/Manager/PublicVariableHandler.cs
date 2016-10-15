using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PublicVariableHandler : MonoBehaviour
{
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //Public Variables

    //Meteor Variables
    public GameObject meteorExplosion;
	public int meteorHealth;

    //Laser Sounds
    public AudioClip laserNoLevelSound;
    public AudioClip laserLevel1Sound;
    public AudioClip laserLevel2Sound;
    public AudioClip laserLevel3Sound;

    //User Interface Variables
    public Image fadeOut;
    public GameObject laserLevel1Bar;
    public GameObject laserLevel2Bar;
    public GameObject laserLevel3Bar;

    public GameObject missileLevel1Bar;
    public GameObject missileLevel2Bar;
    public GameObject missileLevel3Bar;

    public GameObject shieldLevel1Bar;
    public GameObject shieldLevel2Bar;
    public GameObject shieldLevel3Bar;


    public GameObject shieldIcon;
    public GameObject shipIMG1;
    public GameObject shipIMG2;

    //Player Variables
	public GameObject hitEffect;
    public AudioClip hitSound;
    public int healthRecoverScore;
    public float playerShootingFrequency;
    public float lightningGunDuration;
    public int playerShieldHealth;
    public float playerShieldCooldown;
    public int playerLives;
    public int playerHealth;
    public float playerSpeed;
    public float playerRotation;
    public float playerLaserHeatCap;
    public float playerLaserHeatIncreaseAmount;
    public float laserHeatLossAfterSeconds;

    //Enemy Variables
	public float enemyAISpeed;
    public float actorSpeed;
    public float maneuverSpeed;
    public float strafeSpeed;

    //Enemy1
    public float enemy1Speed;
    public float enemy1FireFreq;
    public int enemy1BaseHealth;
    public int enemy1LaserScore;
    public int enemy1MissileScore;

    //Enemy2
    public float enemy2Speed;
    public float enemy2FireFreq;
    public int enemy2BaseHealth;
    public int enemy2LaserScore;
    public int enemy2MissileScore;

    //Enemy3
    public float enemy3Speed;
    public float enemy3FireFreq;
    public int enemy3BaseHealth;
    public int enemy3LaserScore;
    public int enemy3MissileScore;

    //Enemy4
    public float enemy4Speed;
    public float enemy4FireFreq;
    public int enemy4BaseHealth;
    public int enemy4ShieldHealth;
    public int enemy4LaserScore;
    public int enemy4MissileScore;

    //Enemy5
    public int enemy5BaseHealth;
    public int enemy5ShieldHealth;
    public int enemy5LaserScore;


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //Adjust Difficulty Code and Variables\

    public void IncreaseDifficulty()
    {
        //Ship Speed
        //Fire Rate
        //Super Mega Charged Particle Photon Laser of Death Speed Script
    }
}
