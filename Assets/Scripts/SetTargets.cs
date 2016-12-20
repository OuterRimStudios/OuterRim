using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SetTargets : MonoBehaviour
{
    public ObjectPooling pool;
    public GameObject arrowHolder;
    public List<GameObject> pooledShips;
    WaveManager waveManager;

    void Start ()
    {
        waveManager = GameObject.Find("GameManager").GetComponent<WaveManager>();
	    for(int i = 0; i < waveManager.regularEnemyPool.Length; i++)
        {
            for(int j = 0; j < waveManager.regularEnemyPool[i].pooledObjects.Count; j++)
            {
               pooledShips.Add(waveManager.regularEnemyPool[i].pooledObjects[j]);
            }
        }

        for (int k = 0; k < pooledShips.Count; k++)
        {
            GameObject obj = pool.GetPooledObject();
            if (obj == null)
            {
                return;
            }
            obj.SetActive(true);
            obj.transform.SetParent(arrowHolder.transform);
           // obj.GetComponent<TargetTracker>().target = pooledShips[k];
        }
    }
}
