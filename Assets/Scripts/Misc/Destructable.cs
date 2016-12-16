using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Destructable : MonoBehaviour
{
	//[HideInInspector]
	public int baseHealth;
	[HideInInspector]
	public int currentHealth;

    GameObject explosion;
	GameObject gameManager;
	GameObject hitEffect;

	PublicVariableHandler publicVariableHandler;

    void Start()
    {
		gameManager = GameObject.Find("GameManager");
		publicVariableHandler = gameManager.GetComponent<PublicVariableHandler> ();
		explosion = publicVariableHandler.meteorExplosion;
		hitEffect = publicVariableHandler.hitEffect;
		baseHealth = publicVariableHandler.meteorHealth;
		currentHealth = baseHealth;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy Laser" || other.tag == "Laser")
        {
			LoseHealth ();
            //CreateHitEffect(other.gameObject);
			Instantiate (hitEffect, other.transform.position, other.transform.rotation);
			other.GetComponentInChildren<Light> ().enabled = false;
			other.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        }

        if(other.tag == "PlayerCollider")
        {
            other.GetComponent<PlayerCollision>().AsteroidHit();
            Instantiate(explosion, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }

        if(other.tag == "Enemy")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }

	void LoseHealth()
	{
		currentHealth--;
		if (currentHealth <= 0) 
		{
			Instantiate(explosion, transform.position, transform.rotation);
			gameObject.SetActive(false);
		}
	}

    //void CreateHitEffect(GameObject other)
    //{
    //    GameObject obj = hitEffect.GetPooledObject();

    //    if (obj == null)
    //        return;

    //    obj.transform.position = other.transform.position;
    //    obj.transform.rotation = other.transform.rotation;
    //    obj.SetActive(true);
    //}
}
