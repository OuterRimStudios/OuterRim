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
    //void Update()
    //{
    //    if (playerScore.score % spawnAtScore == 0 && playerScore.score != 0 && !spawning && playerScore.score > oldScore)
    //    {
    //        spawning = true;
    //        oldScore = playerScore.score;
    //        SpawnPickUp();
    //        spawning = false;
    //    }

    //}
    public void SpawnPickUp(bool weaponPickUp)
    {
        if (weaponPickUp)
        {
            choose = Random.Range(0, 2);
            if(choose == 0 && laserLevel < 4)
            {
                spawnPoint = new Vector3(Random.Range(player.transform.position.x + xMinSpawn, player.transform.position.x + xMaxSpawn),
                Random.Range(player.transform.position.y + yMinSpawn, player.transform.position.y + yMaxSpawn),
                Random.Range(player.transform.position.z + zSpawnMin, player.transform.position.z + zSpawnMax));
                Instantiate(laserPickUp, spawnPoint, Quaternion.identity);
            }
            else
            {
                spawnPoint = new Vector3(Random.Range(player.transform.position.x + xMinSpawn, player.transform.position.x + xMaxSpawn),
                Random.Range(player.transform.position.y + yMinSpawn, player.transform.position.y + yMaxSpawn),
                Random.Range(player.transform.position.z + zSpawnMin, player.transform.position.z + zSpawnMax));
                Instantiate(missilePickUp, spawnPoint, Quaternion.identity);
            }       
        }
  

        if (!weaponPickUp)
        {
            choose = Random.Range(0, 2);
            if (choose == 0)
            {
                spawnPoint = new Vector3(Random.Range(player.transform.position.x + xMinSpawn, player.transform.position.x + xMaxSpawn),
                Random.Range(player.transform.position.y + yMinSpawn, player.transform.position.y + yMaxSpawn),
                Random.Range(player.transform.position.z + zSpawnMin, player.transform.position.z + zSpawnMax));
                Instantiate(shieldPickUp, spawnPoint, Quaternion.identity);
            }
            if (choose == 1)
            {
                spawnPoint = new Vector3(Random.Range(player.transform.position.x + xMinSpawn, player.transform.position.x + xMaxSpawn),
                Random.Range(player.transform.position.y + yMinSpawn, player.transform.position.y + yMaxSpawn),
                Random.Range(player.transform.position.z + zSpawnMin, player.transform.position.z + zSpawnMax));
                Instantiate(healthPickUp, spawnPoint, Quaternion.identity);
            }
        }
    }

    public void LevelUp(string powerUpType)
    {
        leveled = true;
        switch (powerUpType)
        {
            case "health":
                audioSource.clip = pickupSounds[3];
                audioSource.Play();
                break;
            case "shield":
			    audioSource.clip = pickupSounds [2];
			    audioSource.Play ();
                break;
            case "laser":
			    audioSource.clip = pickupSounds [0];
			    audioSource.Play ();
                if (laserLevel < 3)
                    laserLevel++;
                break;
            case "missile":
			    audioSource.clip = pickupSounds [1];
			    audioSource.Play ();
                if (missileLevel < 3)
                    missileLevel++;
                break;
        }
    }

    public void LoseLevel()
    {
        leveled = false;

        if (laserLevel > 0)
        {
            laserLevel--;
            switch (laserLevel)
            {
                case 0:
                    foreach (GameObject go in player.GetComponent<StoreVariables>().lasers)
                    {
                        go.GetComponent<FireScript>().LaserLevel1(leveled);
                    }
                    break;
                case 1:
                    foreach (GameObject go in player.GetComponent<StoreVariables>().lasers)
                    {
                        go.GetComponent<FireScript>().LaserLevel2(leveled);
                    }
                    break;
                case 2:
				    foreach (GameObject go in player.GetComponent<StoreVariables>().lasers)
				    {
					    go.GetComponent<FireScript>().LaserLevel3(leveled);
				    }
                    break;
            }
        }

        if (missileLevel > 0)
        {
            missileLevel--;
            switch (missileLevel)
            {
                case 0:
                    player.GetComponent<StoreVariables>().missile.GetComponent<FireMissile>().MissileLevel1(leveled);
                    break;
                case 1:
                    player.GetComponent<StoreVariables>().missile.GetComponent<FireMissile>().MissileLevel2(leveled);
                    break;
            }
        }
    }

    public void LoseMissileLevel()
    {
        if (missileLevel == 3)
        {
            missileLevel--;
        }
    }
}