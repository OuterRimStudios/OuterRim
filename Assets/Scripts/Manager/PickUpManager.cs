using UnityEngine;
using System.Collections;

public class PickUpManager : MonoBehaviour
{
    PlayerScore playerScore;

    public GameObject player;
    public GameObject laserPickUp;
    public GameObject missilePickUp;
    public GameObject shieldPickUp;
    public GameObject healthPickUp;
    public GameObject dualLaserPickUp;
	public AudioSource audioSource; //Its the one on the canvas... just go with it
	public AudioClip[] pickupSounds;

    public int laserLevel;
    public int missileLevel;
    public int shieldLevel;

    public int spawnAtScore;
    public int spawnAfter;

    public float xMinSpawn;
    public float xMaxSpawn;

    public float yMinSpawn;
    public float yMaxSpawn;

    public float zSpawnMin;
    public float zSpawnMax;

    public bool leveled;

    PublicVariableHandler publicVariableHandler;

    Vector3 spawnPoint;
    bool spawning;
    int oldScore;
    float x;
    float y;
    int choose;
    int currentLevel;

    void Start()
    {
        player = GameObject.Find("Player");
        playerScore = player.GetComponent<PlayerScore>();
        publicVariableHandler = GetComponent<PublicVariableHandler>();
    }
    public void SpawnPickUp(bool weaponPickUp)
    {
        choose = Random.Range(0, 4);

        switch(choose)
        {
            case 0:
                spawnPoint = new Vector3(Random.Range(player.transform.position.x + xMinSpawn, player.transform.position.x + xMaxSpawn),
                Random.Range(player.transform.position.y + yMinSpawn, player.transform.position.y + yMaxSpawn),
                Random.Range(player.transform.position.z + zSpawnMin, player.transform.position.z + zSpawnMax));
                Instantiate(laserPickUp, spawnPoint, Quaternion.identity);
                break;
            case 1:
                spawnPoint = new Vector3(Random.Range(player.transform.position.x + xMinSpawn, player.transform.position.x + xMaxSpawn),
                Random.Range(player.transform.position.y + yMinSpawn, player.transform.position.y + yMaxSpawn),
                Random.Range(player.transform.position.z + zSpawnMin, player.transform.position.z + zSpawnMax));
                Instantiate(missilePickUp, spawnPoint, Quaternion.identity);
                break;
            case 2:
                spawnPoint = new Vector3(Random.Range(player.transform.position.x + xMinSpawn, player.transform.position.x + xMaxSpawn),
                Random.Range(player.transform.position.y + yMinSpawn, player.transform.position.y + yMaxSpawn),
                Random.Range(player.transform.position.z + zSpawnMin, player.transform.position.z + zSpawnMax));
                Instantiate(shieldPickUp, spawnPoint, Quaternion.identity);
                break;
            case 3:
                spawnPoint = new Vector3(Random.Range(player.transform.position.x + xMinSpawn, player.transform.position.x + xMaxSpawn),
                Random.Range(player.transform.position.y + yMinSpawn, player.transform.position.y + yMaxSpawn),
                Random.Range(player.transform.position.z + zSpawnMin, player.transform.position.z + zSpawnMax));
                Instantiate(dualLaserPickUp, spawnPoint, Quaternion.identity);
                break;
                //case 3:
                //    spawnPoint = new Vector3(Random.Range(player.transform.position.x + xMinSpawn, player.transform.position.x + xMaxSpawn),
                //    Random.Range(player.transform.position.y + yMinSpawn, player.transform.position.y + yMaxSpawn),
                //    Random.Range(player.transform.position.z + zSpawnMin, player.transform.position.z + zSpawnMax));
                //    Instantiate(healthPickUp, spawnPoint, Quaternion.identity);
                //    break;

        }
    }
}