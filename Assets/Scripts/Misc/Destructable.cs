using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Destructable : MonoBehaviour
{
	[HideInInspector]
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
        if (other.tag == "Player" || other.tag == "Enemy" || other.tag == "Enemy Laser" || other.tag == "Laser")
        {
			LoseHealth ();
			if (other.tag == "Enemy Laser" || other.tag == "Laser") 
			{
				Instantiate (hitEffect, other.transform.position, other.transform.rotation);
				other.GetComponentInChildren<Light> ().enabled = false;
				other.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
			}
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
}
