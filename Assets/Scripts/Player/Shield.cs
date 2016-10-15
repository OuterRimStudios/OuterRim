using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour 
{
    public int startingHealth;
    public int currentHealth;
    public GameObject explosion;
    GameObject gameManager;
    GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
		explosion = gameManager.GetComponent<PublicVariableHandler> ().meteorExplosion;
        startingHealth = gameManager.GetComponent<PublicVariableHandler>().playerShieldHealth;
        currentHealth = startingHealth;
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
            Instantiate(explosion, transform.position, transform.rotation);
            other.gameObject.SetActive(false);
            ShieldDestroyed();
        }
        else if (other.tag == "Enemy")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            other.GetComponent<Enemy1Collision>().WasDestroyed();
            ShieldDestroyed();
        }
    }

    void TookDamage()
    {
        currentHealth--;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void ShieldDestroyed()
    {
        gameObject.SetActive(false);
    }
}
