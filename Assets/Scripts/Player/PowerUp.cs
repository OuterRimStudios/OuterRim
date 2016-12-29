using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType
    {
        HEALTH,
        SHIELD,
        LASER,
        DUALLASER,
        Missile,
    }

    public PowerUpType type = PowerUpType.HEALTH;
    PickUpManager pickUpManager;
    AudioSource audioSource;
    public int powerUpLength;
    GameObject player;
    GameObject shield;
    GameObject gameManager;
    bool hit;

    int laserLevel;
    int missileLevel;
    int shieldLevel;

    [HideInInspector]
    public string shieldType;

    [HideInInspector]
    public string laserType;

    [HideInInspector]
    public string missileType;

    [HideInInspector]
    public string healthType;

    void Start()
    {
        player = GameObject.Find("Player");
        shield = player.transform.FindChild("Shield").gameObject;
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager");
        pickUpManager = gameManager.GetComponent<PickUpManager>();
    }
    void ApplyPower()
    {
        switch (type)
        {
            case PowerUpType.HEALTH:
                healthType = "health";
                //pickUpManager.LevelUp(healthType);
                player.GetComponentInChildren<PlayerCollision>().GainLife();
                break;

            case PowerUpType.SHIELD:
                shieldType = "shield";
               // pickUpManager.LevelUp(shieldType);
                player.GetComponent<ActivateShield>().ShieldActive();
                break;

            case PowerUpType.LASER:
                foreach (GameObject go in player.GetComponent<StoreVariables>().lasers)
                {
                    go.GetComponent<FireScript>().LaserUpgrade();
                }
                break;

            case PowerUpType.DUALLASER:
                foreach (GameObject go in player.GetComponent<StoreVariables>().lasers)
                {
                    go.GetComponent<FireScript>().DualLaserUpgrade();
                }
                break;

            case PowerUpType.Missile:
                player.GetComponent<StoreVariables>().missile.GetComponent<FireMissile>().MissilePickUp();
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!hit)
        {
            if (other.name == "Colliders")
            {
                hit = true;
                ApplyPower();
                Destroy(this.gameObject);
            }
        }
    }
}