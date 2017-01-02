using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Destructable : MonoBehaviour
{
	//[HideInInspector]
	public int baseHealth;
	[HideInInspector]
	public int currentHealth;

	GameObject gameManager;
    PlayerScore playerScore;

	PublicVariableHandler publicVariableHandler;
    ObjectPooling hitEffectsPool;
    ObjectPooling meteorExplosions;

    void Start()
    {
		gameManager = GameObject.Find("GameManager");
        playerScore = GameObject.Find("Player").GetComponent<PlayerScore>();
		publicVariableHandler = gameManager.GetComponent<PublicVariableHandler> ();
		baseHealth = publicVariableHandler.meteorHealth;
		currentHealth = baseHealth;
        hitEffectsPool = GameObject.Find("HitEffectPool").GetComponent<ObjectPooling>();
        meteorExplosions = GameObject.Find("MeteorExplosions").GetComponent<ObjectPooling>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Laser")
        {
			LoseHealth ();
            //CreateHitEffect(other.gameObject);
            //Instantiate (hitEffect, other.transform.position, other.transform.rotation);
            SpawnEffect("Hit");
            other.GetComponentInChildren<Light> ().enabled = false;
			other.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        }

        if(other.tag == "PlayerCollider")
        {
            other.GetComponent<PlayerCollision>().AsteroidHit();
            //Instantiate(explosion, transform.position, transform.rotation);
            SpawnEffect("Explosion");
            gameObject.SetActive(false);
        }

        if(other.tag == "Enemy")
        {
            //Instantiate(explosion, transform.position, transform.rotation);
            SpawnEffect("Explosion");
            gameObject.SetActive(false);
        }
    }

	void LoseHealth()
	{
		currentHealth--;
        if (currentHealth <= 0)
        {
            playerScore.score += 100;
            //Instantiate(explosion, transform.position, transform.rotation);
            SpawnEffect("Explosion");
            gameObject.SetActive(false);
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
            case "Hit":
                effect = hitEffectsPool.GetPooledObject();
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
