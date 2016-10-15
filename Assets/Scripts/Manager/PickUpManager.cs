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
	AudioSource audioSource;
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

    GameObject laserLevel1Bar;
    GameObject laserLevel2Bar;
    GameObject laserLevel3Bar;

    GameObject missileLevel1Bar;
    GameObject missileLevel2Bar;
    GameObject missileLevel3Bar;

    GameObject shieldLevel1Bar;
    GameObject shieldLevel2Bar;
    GameObject shieldLevel3Bar;

    PublicVariableHandler publicVariableHandler;

    Vector3 spawnPoint;
    bool spawning;
    int oldScore;
    float x;
    float y;

    void Start()
    {
        player = GameObject.Find("Player");
        playerScore = player.GetComponent<PlayerScore>();
        publicVariableHandler = GetComponent<PublicVariableHandler>();
		audioSource = GetComponent<AudioSource> ();

        laserLevel1Bar = publicVariableHandler.laserLevel1Bar;
        laserLevel2Bar = publicVariableHandler.laserLevel2Bar;
        laserLevel3Bar = publicVariableHandler.laserLevel3Bar;

        missileLevel1Bar = publicVariableHandler.missileLevel1Bar;
        missileLevel2Bar = publicVariableHandler.missileLevel2Bar;
        missileLevel3Bar = publicVariableHandler.missileLevel3Bar;

        shieldLevel1Bar = publicVariableHandler.shieldLevel1Bar;
        shieldLevel2Bar = publicVariableHandler.shieldLevel2Bar;
        shieldLevel3Bar = publicVariableHandler.shieldLevel3Bar;
    }
    void Update()
    {
        if (playerScore.score % spawnAtScore == 0 && playerScore.score != 0 && !spawning && playerScore.score > oldScore)
        {
            spawning = true;
            oldScore = playerScore.score;
            SpawnPickUp();
            spawning = false;
        }

    }
    void SpawnPickUp()
    {
        spawnPoint = new Vector3(Random.Range(player.transform.position.x + xMinSpawn, player.transform.position.x + xMaxSpawn),
        Random.Range(player.transform.position.y + yMinSpawn, player.transform.position.y + yMaxSpawn),
        Random.Range(player.transform.position.z + zSpawnMin, player.transform.position.z + zSpawnMax));
        Instantiate(laserPickUp, spawnPoint, Quaternion.identity);
        
        spawnPoint = new Vector3(Random.Range(player.transform.position.x + xMinSpawn, player.transform.position.x + xMaxSpawn),
        Random.Range(player.transform.position.y + yMinSpawn, player.transform.position.y + yMaxSpawn),
        Random.Range(player.transform.position.z + zSpawnMin, player.transform.position.z + zSpawnMax));
        Instantiate(missilePickUp, spawnPoint, Quaternion.identity);

        spawnPoint = new Vector3(Random.Range(player.transform.position.x + xMinSpawn, player.transform.position.x + xMaxSpawn),
        Random.Range(player.transform.position.y + yMinSpawn, player.transform.position.y + yMaxSpawn),
        Random.Range(player.transform.position.z + zSpawnMin, player.transform.position.z + zSpawnMax));
        Instantiate(shieldPickUp, spawnPoint, Quaternion.identity);

        spawnPoint = new Vector3(Random.Range(player.transform.position.x + xMinSpawn, player.transform.position.x + xMaxSpawn),
        Random.Range(player.transform.position.y + yMinSpawn, player.transform.position.y + yMaxSpawn),
        Random.Range(player.transform.position.z + zSpawnMin, player.transform.position.z + zSpawnMax));
        Instantiate(healthPickUp, spawnPoint, Quaternion.identity);
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
                    laserLevel1Bar.SetActive(false);
                    foreach (GameObject go in player.GetComponent<StoreVariables>().lasers)
                    {
                        go.GetComponent<FireScript>().LaserLevel1(leveled);
                    }
                    break;
                case 1:
                    laserLevel2Bar.SetActive(false);
                    foreach (GameObject go in player.GetComponent<StoreVariables>().lasers)
                    {
                        go.GetComponent<FireScript>().LaserLevel2(leveled);
                    }
                    break;
                case 2:
                    laserLevel3Bar.SetActive(false);
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
                    missileLevel1Bar.SetActive(false);
                    player.GetComponent<StoreVariables>().missile.GetComponent<FireMissile>().MissileLevel1(leveled);
                    break;
                case 1:
                    missileLevel2Bar.SetActive(false);
                    player.GetComponent<StoreVariables>().missile.GetComponent<FireMissile>().MissileLevel2(leveled);
                    break;
                case 2:
                    missileLevel3Bar.SetActive(false);
                    break;
            }
        }
    }

    public void LoseMissileLevel()
    {
        if (missileLevel == 3)
        {
            missileLevel--;
			missileLevel3Bar.SetActive (false);
        }
    }
}