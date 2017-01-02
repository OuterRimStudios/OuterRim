using UnityEngine;
using System.Collections;

public class EnemyShield : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;
    GameObject gameManager;
    GameObject player;
    Enemy1Collision collisionScript;
    ObjectPooling meteorExplosions;

    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");

        switch (transform.parent.name)
        {
            case "BasicShip":
                startingHealth = gameManager.GetComponent<PublicVariableHandler>().enemy4ShieldHealth;
                break;
            case "Enemy 04":
                startingHealth = gameManager.GetComponent<PublicVariableHandler>().enemy4ShieldHealth;
                break;
            //case "Enemy5":
            //    startingHealth = gameManager.GetComponent<PublicVariableHandler>().enemy5ShieldHealth;
            //    break;
        }

        currentHealth = startingHealth;
        collisionScript = GetComponentInParent<Enemy1Collision>();
        collisionScript.enabled = false;
        meteorExplosions = GameObject.Find("MeteorExplosions").GetComponent<ObjectPooling>();
    }

    public void OnSpawn()
    {
        currentHealth = startingHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser")
        {
            other.gameObject.SetActive(false);
            currentHealth--;
            if (currentHealth <= 0)
            {
                collisionScript.enabled = true;
                gameObject.SetActive(false);
            }
        }

        if (transform.parent.tag != "Carrier")
        {
            if (other.tag == "Meteor")
            {
                SpawnEffect("Explosion");
                //Instantiate(meteorExplosionPrefab, transform.position, transform.rotation);
                other.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }

    public void SpawnEffect(string type)
    {
        GameObject effect = null;
        switch (type)
        {
            case "Explosion":
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