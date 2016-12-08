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
    public float laserPickUpActiveTime;
    public float dualLaserPickUpActiveTime;
    public float missileRechargeLength;

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
    public float enemy5Speed;
    public float enemy5FireFreq;
    public int enemy5BaseHealth;
    public int enemy5LaserScore;
    public int enemy5MissileScore;

    //Enemy6
    public float enemy6Speed;
    public float enemy6FireFreq;
    public int enemy6BaseHealth;
    public int enemy6LaserScore;
    public int enemy6MissileScore;

    //Enemy7
    public float enemy7Speed;
    public float enemy7FireFreq;
    public int enemy7BaseHealth;
    public int enemy7LaserScore;
    public int enemy7MissileScore;

    //Enemy8
    public float enemy8Speed;
    public float enemy8FireFreq;
    public int enemy8BaseHealth;
    public int enemy8LaserScore;
    public int enemy8MissileScore;

    //Enemy9
    public float enemy9Speed;
    public float enemy9FireFreq;
    public int enemy9BaseHealth;
    public int enemy9LaserScore;
    public int enemy9MissileScore;

    //Enemy10
    public float enemy10Speed;
    public float enemy10FireFreq;
    public int enemy10BaseHealth;
    public int enemy10LaserScore;
    public int enemy10MissileScore;

    //Enemy11
    public float enemy11Speed;
    public float enemy11FireFreq;
    public int enemy11BaseHealth;
    public int enemy11LaserScore;
    public int enemy11MissileScore;

    //Enemy12
    public float enemy12Speed;
    public float enemy12FireFreq;
    public int enemy12BaseHealth;
    public int enemy12LaserScore;
    public int enemy12MissileScore;

    //Carrier
    public float carrierSpeed;
    public int carrierBaseHealth;
    public int carrierScore;


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    //Adjust Difficulty Code and Variables\

    float fireRateCap = 1;

    float enemy4ShieldCap = 16;

    float enemy1SpeedCap = 400;
    float enemy2SpeedCap = 400;
    float enemy3SpeedCap = 1200;
    float enemy4SpeedCap = 1000;
    float enemy5SpeedCap = 1000;
    float enemy6SpeedCap = 400;
    float enemy7SpeedCap = 400;
    float enemy8SpeedCap = 400;
    float enemy9SpeedCap = 400;
    float enemy10SpeedCap = 400;
    float enemy11SpeedCap = 1000;
    float enemy12SpeedCap = 1000;

    int enemy1HealthCap = 16;
    int enemy2HealthCap = 28;
    int enemy3HealthCap = 16;
    int enemy4HealthCap = 12;
    int enemy5HealthCap = 16;
    int enemy6HealthCap = 16;
    int enemy7HealthCap = 16;
    int enemy8HealthCap = 16;
    int enemy9HealthCap = 16;
    int enemy10HealthCap = 16;
    int enemy11HealthCap = 16;
    int enemy12HealthCap = 16;

    WaveManager waveManager;

    void Start()
    {
        waveManager = GetComponent<WaveManager>();
    }
    public void IncreaseWavePool()
    {
        if (waveManager.maxHPAllowed <= 250)
            waveManager.maxHPAllowed += 5;
    }
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
        if (enemy5FireFreq < fireRateCap)
            enemy5FireFreq -= .2f;
        if (enemy6FireFreq < fireRateCap)
            enemy6FireFreq -= .2f;
        if (enemy7FireFreq < fireRateCap)
            enemy7FireFreq -= .2f;
        if (enemy8FireFreq < fireRateCap)
            enemy8FireFreq -= .2f;
        if (enemy9FireFreq < fireRateCap)
            enemy9FireFreq -= .2f;
        if (enemy10FireFreq < fireRateCap)
            enemy10FireFreq -= .2f;
        if (enemy11FireFreq < fireRateCap)
            enemy11FireFreq -= .2f;
        if (enemy12FireFreq < fireRateCap)
            enemy12FireFreq -= .2f;

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
        if (enemy5Speed < enemy5SpeedCap)
            enemy5Speed += 50;
        if (enemy6Speed < enemy6SpeedCap)
            enemy6Speed += 50;
        if (enemy7Speed < enemy7SpeedCap)
            enemy7Speed += 50;
        if (enemy8Speed < enemy8SpeedCap)
            enemy8Speed += 50;
        if (enemy9Speed < enemy9SpeedCap)
            enemy9Speed += 50;
        if (enemy10Speed < enemy10SpeedCap)
            enemy10Speed += 50;
        if (enemy11Speed < enemy11SpeedCap)
            enemy11Speed += 50;
        if (enemy12Speed < enemy12SpeedCap)
            enemy12Speed += 50;

        //Increases the health for all ships
        if (enemy1BaseHealth < enemy1HealthCap)
            enemy1BaseHealth += 3;
        if (enemy2BaseHealth < enemy2HealthCap)
            enemy2BaseHealth += 3;
        if (enemy3BaseHealth < enemy3HealthCap)
            enemy3BaseHealth += 3;
        if (enemy4BaseHealth < enemy4HealthCap)
            enemy4BaseHealth += 3;
        if (enemy5BaseHealth < enemy5HealthCap)
            enemy5BaseHealth += 3;
        if (enemy6BaseHealth < enemy6HealthCap)
            enemy6BaseHealth += 3;
        if (enemy7BaseHealth < enemy7HealthCap)
            enemy7BaseHealth += 3;
        if (enemy8BaseHealth < enemy8HealthCap)
            enemy8BaseHealth += 3;
        if (enemy9BaseHealth < enemy9HealthCap)
            enemy9BaseHealth += 3;
        if (enemy10BaseHealth < enemy10HealthCap)
            enemy10BaseHealth += 3;
        if (enemy11BaseHealth < enemy11HealthCap)
            enemy11BaseHealth += 3;
        if (enemy12BaseHealth < enemy12HealthCap)
            enemy12BaseHealth += 3;
    }
}
