using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour 
{
    public int startingHealth;
    public int currentHealth;
    public GameObject explosion;
    GameObject gameManager;
    GameObject player;
    PublicVariableHandler publicVariableHandler;
    ObjectPooling meteorExplosions;

    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        publicVariableHandler = gameManager.GetComponent<PublicVariableHandler>();
        startingHealth = publicVariableHandler.playerShieldHealth;
        currentHealth = startingHealth;
        meteorExplosions = GameObject.Find("MeteorExplosions").GetComponent<ObjectPooling>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy Laser")
        {
            other.gameObject.SetActive(false);
            TookDamage();
        }
        else if (other.tag == "Meteor")
        {
            SpawnEffect("MeteorExplosion");
            //Instantiate(explosion, transform.position, transform.rotation);
            other.gameObject.SetActive(false);
            ShieldDestroyed();
        }
        else if (other.tag == "Enemy")
        {
            SpawnEffect("ShipExplosion");
            //Instantiate(explosion, transform.position, transform.rotation);
            other.GetComponent<Enemy1Collision>().WasDestroyed(false);
            ShieldDestroyed();
        }
    }

    void TookDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            player.transform.Find("ShipContainer").Find("Colliders").GetComponent<PlayerCollision>().enabled = true;
            gameObject.SetActive(false);
        }
    }

    void ShieldDestroyed()
    {
        player.transform.Find("ShipContainer").Find("Colliders").GetComponent<PlayerCollision>().enabled = true;
        gameObject.SetActive(false);
    }

    public void SpawnEffect(string type)
    {
        GameObject effect = null;
        switch (type)
        {
            case "ShipExplosion":
                effect = publicVariableHandler.shipExplosionPools[Random.Range(0, publicVariableHandler.shipExplosionPools.Length)].GetPooledObject();
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
}
