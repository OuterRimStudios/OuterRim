using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomSkybox : MonoBehaviour
{
	public List<GameObject> skyboxes;
	public List<GameObject> originalSkyboxes;
	int random;

	void Start()
	{
		foreach (GameObject skybox in skyboxes)
		{
			originalSkyboxes.Add(skybox);
		}
		random = Random.Range(0, skyboxes.Count);
		skyboxes[random].SetActive(true);
	}

	public void NewSkybox()
	{
		if(skyboxes.Count != 0)
		{
			foreach (GameObject go in skyboxes)
			{
				if(go.activeInHierarchy)
				{
					StartCoroutine (Warping (go));
					break;
				}

			}
		}
		else
		{
			foreach(GameObject originalSkybox in originalSkyboxes)
			{
				skyboxes.Add(originalSkybox);
			}

			int newRandom = Random.Range(0, skyboxes.Count);
			skyboxes[newRandom].SetActive(true);
		}
	}  

	IEnumerator Warping (GameObject oldSkybox)
	{
		yield return new WaitForSeconds (1);
		oldSkybox.SetActive (false);
		skyboxes.Remove(oldSkybox);	
		int newRandom = Random.Range(0, skyboxes.Count);
		if (skyboxes.Count != 0)
		{
			skyboxes[newRandom].SetActive(true);		
		}
		else
		{
			foreach (GameObject originalSkybox in originalSkyboxes)
			{
				skyboxes.Add(originalSkybox);
			}

			newRandom = Random.Range(0, skyboxes.Count);
			skyboxes[newRandom].SetActive(true);
		}
	}
}
