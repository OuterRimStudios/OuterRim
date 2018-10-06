using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooling : MonoBehaviour
{
    public GameObject[] pooledObject;
    public int pooledAmount;
    public float waitTime = 0.001f;
    public bool willGrow = true;

    public List<GameObject> pooledObjects;
    GameObject animationObject;

	// Use this for initialization
	void Start ()
    {
        animationObject = GameObject.Find("AnimationObject");
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            StartCoroutine(InstantiatePool(waitTime));
            //GameObject obj = (GameObject)Instantiate(pooledObject);
            //obj.SetActive(false);
            //pooledObjects.Add(obj);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        if (willGrow)
        {
            for (int i = 0; i < pooledObject.Length; i++)
            {
                GameObject obj = (GameObject)Instantiate(pooledObject[i]);
                obj.transform.parent = transform;
                pooledObjects.Add(obj);
                return obj;
            }
        }

        return null;
    }

    IEnumerator InstantiatePool(float waitTime)
    {
        for (int i = 0; i < pooledObject.Length; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject[i]);
            obj.transform.parent = transform;
            
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }

        yield return new WaitForSeconds(waitTime);
    }
}

/*
 * object to pool
 * amount of objects to pool
 * list to hold pooled objects
 * current pooled object
 * bool to allow instantiation of objects when pool is empty
 * 
*/