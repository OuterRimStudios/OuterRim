using UnityEngine;
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

	GameObject hitEffect;
    GameObject gameManager;
    FireMissile fireMissile;
    PlayerScore _playerScore;
    PlayerCollision playerCollision;
    AchievementManager achievementManager;
    PublicVariableHandler publicVariableHandler;

    ObjectPooling explosionPool;
    ObjectPooling hitEffectsPool;
    ObjectPooling meteorExplosions;

    void Awake()
    {
        player = GameObject.Find("Player");
        _playerScore = player.GetComponent<PlayerScore>();
        gameManager = GameObject.Find("GameManager");
        publicVariableHandler = gameManager.GetComponent<PublicVariableHandler>();
        achievementManager = gameManager.GetComponent<AchievementManager>();
        hitEffect = publicVariableHandler.hitEffect;
        fireMissile = GameObject.Find("MissileNozzle").GetComponent<FireMissile>();
        hitEffectsPool = GameObject.Find("HitEffectPool").GetComponent<ObjectPooling>(); 
        meteorExplosions = GameObject.Find("MeteorExplosions").GetComponent<ObjectPooling>();
    }

    void Start()
    {
        if(transform.name == "BasicShip")
        {
            transform.FindChild("Shield").gameObject.SetActive(true);
        }
    }
    
    public void OnSpawned()
    {
        if (transform.tag == "Enemy")
        {
            switch (transform.name)
            {
                case "BasicShip":
                    laserScore = publicVariableHandler.enemy4LaserScore;
                    missileScore = publicVariableHandler.enemy4MissileScore;
                    baseHealth = publicVariableHandler.enemy4BaseHealth;
                    transform.FindChild("Shield").gameObject.SetActive(true);
                    break;
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
                    transform.FindChild("Shield").gameObject.SetActive(true);
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
            col.gameObject.SetActive(false);
            TookDamage(col.transform.position);
        }
        else if (col.gameObject.tag == "Missile")
        {
            fireMissile.hasTarget = false;
            WasDestroyed(true);
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Meteor")
        {
            SpawnEffect("MeteorExplosion");
            col.gameObject.SetActive(false);
            // WasDestroyed(false);
        }
    }

    public void TookDamage()
    {
        SpawnEffect("Hit");
        currentHealth--;
        if (currentHealth <= 0)
        {
            WasDestroyed(true);
        }
    }

    public void TookDamage(Vector3 hitPosition)
    {
        SpawnEffect(hitPosition);
        currentHealth--;
        if (currentHealth <= 0)
        {
            WasDestroyed(true);
        }
    }

    public void WasDestroyed(bool givePoints)
    {
        fireMissile.targetsInRange.Remove(gameObject);
        if(fireMissile.target == gameObject)
        {
            fireMissile.hasTarget = false;
        }

        if(givePoints)
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

        if(transform.tag != "Carrier")
        {
            SpawnEffect("ShipExplosion");
            gameObject.SetActive(false);
        }
        else
        {
            SpawnEffect("CarrierExplosion");
            gameObject.SetActive(false);
        }
    }

    public void SpawnEffect(string type)
    {
        GameObject effect = null;
        switch (type)
        {
            case "ShipExplosion":
                effect = publicVariableHandler.shipExplosionPools[Random.Range(0, publicVariableHandler.shipExplosionPools.Length)].GetPooledObject();
                break;
            case "CarrierExplosion":
                effect = publicVariableHandler.carrierExplosionPools[Random.Range(0, publicVariableHandler.carrierExplosionPools.Length)].GetPooledObject();
                break;
            case "MeteorExplosion":
                effect = meteorExplosions.GetPooledObject();
                break;
            default:
                effect = null;
                break;
        }
        

        if (effect == null)
            return;

        effect.transform.position = transform.position;
        effect.SetActive(true);
    }

    void SpawnEffect(Vector3 positionHit)
    {
        GameObject effect = null;
        effect = hitEffectsPool.GetPooledObject();
        if (effect == null)
            return;

        effect.transform.position = positionHit;
        effect.SetActive(true);
    }
}