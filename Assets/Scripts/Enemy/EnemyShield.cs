using UnityEngine;
using System.Collections;

public class EnemyShield : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;
    public GameObject meteorExplosionPrefab;
    GameObject gameManager;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");

        switch (transform.parent.name)
        {
            case "Enemy4":
                startingHealth = gameManager.GetComponent<PublicVariableHandler>().enemy4ShieldHealth;
                break;
            case "Enemy5":
                startingHealth = gameManager.GetComponent<PublicVariableHandler>().enemy5ShieldHealth;
                break;
        }

        currentHealth = startingHealth;
        GetComponentInParent<Enemy1Collision>().enabled = false;
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
                GetComponentInParent<Enemy1Collision>().enabled = true;
                gameObject.SetActive(false);
            }
        }

        if (transform.parent.name != "Enemy5")
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