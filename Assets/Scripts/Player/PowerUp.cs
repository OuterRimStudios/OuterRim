using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    public enum PowerUpType
    {
        HEALTH,
        SHIELD,
        LASER,
        Missile,
    }

    public PowerUpType type = PowerUpType.HEALTH;
    PickUpManager pickUpManager;
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
        gameManager = GameObject.Find("GameManager");
        pickUpManager = gameManager.GetComponent<PickUpManager>();
		    }
    void ApplyPower()
    {
        switch (type)
        {
            case PowerUpType.HEALTH:
                healthType = "health";
                pickUpManager.LevelUp(healthType);
                player.GetComponentInChildren<PlayerCollision>().GainLife();
                break;

            case PowerUpType.SHIELD:
                shieldType = "shield";
                pickUpManager.LevelUp(shieldType);
                player.GetComponent<StoreVariables>().shield.SetActive(true);
                break;

            case PowerUpType.LASER:

                laserType = "laser";
                pickUpManager.LevelUp(laserType);
                laserLevel = pickUpManager.laserLevel;

                switch (laserLevel)
                {
                    case 1:
                        foreach (GameObject go in player.GetComponent<StoreVariables>().lasers)
                        {
                            go.GetComponent<FireScript>().LaserLevel1(pickUpManager.leveled);
                        }
                        break;
                    case 2:
                        foreach (GameObject go in player.GetComponent<StoreVariables>().lasers)
                        {
                            go.GetComponent<FireScript>().LaserLevel2(pickUpManager.leveled);
                        }
                        break;
                    case 3:
                        foreach (GameObject go in player.GetComponent<StoreVariables>().lasers)
                        {
                            go.GetComponent<FireScript>().LaserLevel3(pickUpManager.leveled);
                        }
                        break;
                }

                break;

            case PowerUpType.Missile:

                missileType = "missile";
                pickUpManager.LevelUp(missileType);
                missileLevel = pickUpManager.missileLevel;
                switch (missileLevel)
                {
                    case 1:
                        player.GetComponent<StoreVariables>().missile.GetComponent<FireMissile>().MissileLevel1(pickUpManager.leveled);
                        break;
                    case 2:
                        player.GetComponent<StoreVariables>().missile.GetComponent<FireMissile>().MissileLevel2(pickUpManager.leveled);
                        break;
                    case 3:
                        player.GetComponent<StoreVariables>().missile.GetComponent<FireMissile>().MissileLevel3(pickUpManager.leveled);
                        break;
                }

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