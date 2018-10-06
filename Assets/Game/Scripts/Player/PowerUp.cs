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
    PublicVariableHandler publicVariableHandler;
    public AudioSource audioSource;
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
        shield = player.transform.Find("Shield").gameObject;
        audioSource = GameObject.Find("Canvas").GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager");
        pickUpManager = gameManager.GetComponent<PickUpManager>();
        publicVariableHandler = gameManager.GetComponent<PublicVariableHandler>();
    }
    void ApplyPower()
    {
        switch (type)
        {
            case PowerUpType.HEALTH:
                healthType = "health";
                audioSource.clip = publicVariableHandler.shieldPickUpSound;
                audioSource.PlayOneShot(audioSource.clip);
                player.GetComponentInChildren<PlayerCollision>().GainLife();
                break;

            case PowerUpType.SHIELD:
                shieldType = "shield";
                // pickUpManager.LevelUp(shieldType);
                audioSource.clip = publicVariableHandler.shieldPickUpSound;
                audioSource.PlayOneShot(audioSource.clip);
                player.GetComponent<ActivateShield>().ShieldActive();
                break;

            case PowerUpType.LASER:
                audioSource.clip = publicVariableHandler.laserPickUpSound;
                audioSource.PlayOneShot(audioSource.clip);
                foreach (GameObject go in player.GetComponent<StoreVariables>().lasers)
                {
                    go.GetComponent<FireScript>().LaserUpgrade();
                }
                break;

            case PowerUpType.DUALLASER:
                audioSource.clip = publicVariableHandler.dualLaserPickUpSound;
                audioSource.PlayOneShot(audioSource.clip);
                foreach (GameObject go in player.GetComponent<StoreVariables>().lasers)
                {
                    go.GetComponent<FireScript>().DualLaserUpgrade();
                }
                break;

            case PowerUpType.Missile:
                audioSource.clip = publicVariableHandler.missilePickUpSound;
                audioSource.PlayOneShot(audioSource.clip);
                player.GetComponent<StoreVariables>().missile.GetComponent<FireMissile>().MissilePickUp();
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!hit)
        {
            if (other.name == "Colliders" || other.tag == "PlayerCollider")
            {
                hit = true;
                ApplyPower();
                Destroy(gameObject);
            }
        }
    }
}