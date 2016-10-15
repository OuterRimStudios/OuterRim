using UnityEngine;
using System.Collections;

public class DebrisField : MonoBehaviour 
{
    public GameObject[] objectTypes;
    ObjectPooling[] objectPools;
    GameObject player;                  //Player ship.
    Vector3 objectSpawn;
    public float objSpawnMinX;
    public float objSpawnMaxX;
    public float objSpawnMinY;
    public float objSpawnMaxY;
    public float spawnFrequency;
    public float objSpawnZ;
    bool spawning;
    public Vector3[] sizes;
	// Use this for initialization
	void Start () 
    {
        player = GameObject.Find("Player");
        objectPools = new ObjectPooling[objectTypes.Length];
        for(int i = 0; i < objectTypes.Length; i++)
        {
            objectPools[i] = objectTypes[i].GetComponent<ObjectPooling>();
        }
	}
	
	// Update is called once per frame
    void Update()
    {
        StartSpawning();
    }

    IEnumerator ObjSpawn() 
    {

        if (!spawning)
        {
            spawning = true;

            yield return new WaitForSeconds(spawnFrequency);

            GameObject obj = ChooseObject();

            if (obj == null)
            {
                yield break;
            }

            //objectTypes[Random.Range(0, objectTypes.Length)].gameObject.transform.localScale = sizes[Random.Range(0, sizes.Length)];
            objectSpawn = new Vector3(player.transform.position.x + Random.Range(objSpawnMinX, objSpawnMaxX), 
                player.transform.position.y + Random.Range(objSpawnMinY, objSpawnMaxY), player.transform.position.z + objSpawnZ);
            obj.transform.position = objectSpawn;
            obj.transform.localScale = sizes[Random.Range(0, sizes.Length)];
           // obj.GetComponent<Destructable>().sploded = true;
            obj.SetActive(true);
            spawning = false;
        }
	}

    GameObject ChooseObject()
    {
        GameObject choosenObject;
        int index = Random.Range(0, objectTypes.Length - 1);

        switch (index)
        {
            case 0:
                choosenObject = objectPools[0].GetPooledObject();
                break;
            case 1:
                choosenObject = objectPools[1].GetPooledObject();
                break;
            case 2:
                choosenObject = objectPools[2].GetPooledObject();
                break;
            case 3:
                choosenObject = objectPools[3].GetPooledObject();
                break;
            default:
                choosenObject = null;
                break;
        }

        return choosenObject;
    }

    void StartSpawning()
    {
        StartCoroutine(ObjSpawn());
    }
}

