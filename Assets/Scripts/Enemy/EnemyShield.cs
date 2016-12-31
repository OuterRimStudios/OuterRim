using UnityEngine;
using System.Collections;

public class EnemyShield : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;
    public GameObject meteorExplosionPrefab;
    GameObject gameManager;
    GameObject player;
    Enemy1Collision collisionScript;

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
        meteorExplosionPrefab = player.GetComponent<StoreVariables>().meteorExplosion;
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
                Instantiate(meteorExplosionPrefab, transform.position, transform.rotation);
                other.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}