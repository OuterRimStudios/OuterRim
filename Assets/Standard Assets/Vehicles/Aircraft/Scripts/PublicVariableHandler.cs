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

    float fireRateCap = 1;

    float enemy4ShieldCap = 16;

    float enemy1SpeedCap = 400;
    float enemy2SpeedCap = 400;
    float enemy3SpeedCap = 1200;
    float enemy4SpeedCap = 1000;

    int enemy1HealthCap = 16;
    int enemy2HealthCap = 28;
    int enemy3HealthCap = 16;
    int enemy4HealthCap = 12;

    public void IncreaseDifficulty()
    {
        //Increases the fire rate for all ships
        if (enemy1FireFreq < fireRateCap)
            enemy1FireFreq -= .2f;
        if (enemy2FireFreq < fireRateCap)
            enemy2FireFreq -= .2f;
        if (enemy3FireFreq < fireRateCap)
            enemy3FireFreq -= .2f;
        if (enemy4FireFreq < fireRateCap)
            enemy4FireFreq -= .2f;

        //Increases the health of the shields for all ships with shields
        if (enemy4ShieldHealth < enemy4ShieldCap)
            enemy4ShieldHealth += 1;

        //Increases the speed for all ships
        if (enemy1Speed < enemy1SpeedCap)
            enemy1Speed += 50;
        if (enemy2Speed < enemy2SpeedCap)
            enemy2Speed += 50;
        if (enemy3Speed < enemy3SpeedCap)
            enemy3Speed += 50;
        if (enemy4Speed < enemy4SpeedCap)
            enemy4Speed += 50;

        //Increases the health for all ships
        if (enemy1BaseHealth < enemy1HealthCap)
            enemy1BaseHealth += 3;
        if (enemy2BaseHealth < enemy2HealthCap)
            enemy2BaseHealth += 3;
        if (enemy3BaseHealth < enemy3HealthCap)
            enemy3BaseHealth += 3;
        if (enemy4BaseHealth < enemy4HealthCap)
            enemy4BaseHealth += 3;
    }
}
