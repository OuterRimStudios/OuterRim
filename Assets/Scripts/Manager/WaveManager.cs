using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    //This Wave Manager spawns enemies based upon their health. It checks what the allowed health amount you set is and spawns enemies until it hits that amount.
    [Tooltip("This is the max hp ever allowed.")]
    public float maxHPAllowed;
    [Tooltip("Total allowed Health Pofloats. changing this will increase the amount of ships that could spawn.")]
     float AllowedHP;
    [Tooltip("How much total Health Pofloats are active right now. This correlates to how many ships are active.")]
    public float currentHPUsed;
    [Tooltip("How much will the Allowed HP increase by every wave complete.")]
    public float AllowHPIncreaseAmount;
    [Tooltip("This array should be populated with the pools of all the basic enemies in order from hardest to easiest. This excludes Kamikaze and Carrier ships.")]
    public ObjectPooling[] regularEnemyPool;
    [Tooltip("This array should be populated with all the enemy carrier PREFABS.")]
    public GameObject[] carrierEnemies;
    //[Tooltip("This array should be populated with all the enemy kamikaze PREFABS.")]
    //public GameObject[] kamikazeEnemies;
    [Tooltip("This number refers to a wave. If you want the carrier to spawn every 10 waves you would put 10 in here.")]
    public float spawnCarrierAt;
    //[Tooltip("This number refers to a wave. If you want the kamikaze to spawn every 10 waves you would put 10 in here.")]
    //public float spawnKamikazeAt;
    [HideInInspector]
    public Vector3 spawnLocation;

    public float sectorCompleteAt;
    public float quadrentCompleteAt;

    public float minXSpawn;
    public float maxXspawn;
    public float minYSpawn;
    public float maxYSpawn;
    public float zSpawn;

    public List<GameObject> activeEnemies;

    public Text waveStartingText;
    public Text waveCompleteText;

    public GameObject badge1;
    public GameObject badge2;
    public GameObject badge3;
    public GameObject quadrentBadge;
    public Text quadrentBadgeText;

    private GameObject player;
    private bool canSpawn;
    private bool sectorWasCompleted;
    private int newEnemyCount;  //This increases the pool size.
    private float waveCount;
    float sectorNum;
    float quadNum;
    int badgeAmt;

	void Start ()
    {
        canSpawn = true;
        player = GameObject.Find("Player");
        ChooseLocation();
        StartCoroutine(WaveStarting());
	}

    public Vector3 ChooseLocation()
    {
        spawnLocation = new Vector3(player.transform.position.x + Random.Range(minXSpawn, maxXspawn),
        player.transform.position.y + Random.Range(minYSpawn, maxYSpawn), player.transform.position.z + zSpawn);
        return spawnLocation;
    }

	void Spawn ()
    {
        if (canSpawn)
        {
            while (currentHPUsed < AllowedHP)
            {
                print("spawning");
                GameObject obj = regularEnemyPool[Random.Range(0, newEnemyCount)].GetPooledObject();

                if (obj == null)
                {
                    return;
                }
                currentHPUsed += obj.GetComponent<Enemy1Collision>().baseHealth;

                obj.transform.position = new Vector3(player.transform.position.x + Random.Range(minXSpawn, maxXspawn),
                player.transform.position.y + Random.Range(minYSpawn, maxYSpawn), player.transform.position.z + zSpawn);
                obj.transform.rotation = transform.rotation;
                obj.SetActive(true);
                activeEnemies.Add(obj);
                obj.GetComponent<Enemy1Collision>().OnSpawned();
                
                if (currentHPUsed >= AllowedHP)
                {
                    canSpawn = false;
                    print("You spawned more than the allowed amount " + canSpawn);
                }
            }
        }
	}

    IEnumerator SectorCompleted()
    {
        waveStartingText.gameObject.SetActive(false);
        sectorNum++;
        waveCompleteText.gameObject.SetActive(true);
        waveCompleteText.text = "Sector " + sectorNum + " Cleared!";

       
        if (badgeAmt < 4)
        {
            badgeAmt++;
        }
        else
        {
            badgeAmt = 1;
        }
        switch (badgeAmt)
        {
            case 1:
                yield return new WaitForSeconds(1);
                badge1.SetActive(true);
                break;
            case 2:
                badge1.SetActive(true);
                yield return new WaitForSeconds(1);
                badge2.SetActive(true);
                break;
            case 3:
                badge1.SetActive(true);
                badge2.SetActive(true);
                yield return new WaitForSeconds(1);
                badge3.SetActive(true);
                break;
            case 4:
                badge1.SetActive(false);
                yield return new WaitForSeconds(.5f);
                badge2.SetActive(false);
                yield return new WaitForSeconds(.5f);
                badge3.SetActive(false);
                yield return new WaitForSeconds(.5f);
                quadNum++;
                quadrentBadge.SetActive(true);
                quadrentBadgeText.text = "" + quadNum;
                yield return new WaitForSeconds(2f);
                quadrentBadge.SetActive(false);
                break;
        }

        yield return new WaitForSeconds(2);
        waveCompleteText.gameObject.SetActive(false);

        badge1.SetActive(false);
        badge2.SetActive(false);
        badge3.SetActive(false);
        yield return new WaitForSeconds(2);
        sectorWasCompleted = false;
    }

    IEnumerator WaveStarting()
    {
        if (AllowedHP < maxHPAllowed)
        {
            AllowedHP += AllowHPIncreaseAmount;
        }

        //if (waveCount % spawnCarrierAt == 0 && waveCount != 0)
        //{
        //    print("Carrier spawned");
        //    Instantiate(carrierEnemies[Random.Range(0, carrierEnemies.Length)], spawnLocation, Quaternion.identity);
        //}
        //if (waveCount % spawnKamikazeAt == 0 && waveCount != 0)
        //{
        //        Instantiate(kamikazeEnemies[Random.Range(0, carrierEnemies.Length)], new Vector3(player.transform.position.x + Random.Range(minXSpawn, maxXspawn),
        //        player.transform.position.y + Random.Range(minYSpawn, maxYSpawn), player.transform.position.z + zSpawn), Quaternion.identity);
        //}
        if (newEnemyCount < regularEnemyPool.Length)
        {
            newEnemyCount++;
        }
            waveCount++;

        if (waveCount % sectorCompleteAt == 0 && waveCount != 0 && sectorCompleteAt != 0)
        {
            print("WaveCount is: " + waveCount + "A sector is complete at: " + sectorCompleteAt + "Modulation Resutls: " + waveCount % sectorCompleteAt);
            print("SectorCompleted");
            sectorWasCompleted = true;
            StartCoroutine(SectorCompleted());
            yield return new WaitForSeconds(3);
        }


        waveStartingText.gameObject.SetActive(true);
        waveStartingText.text = "Wave " + waveCount;
        yield return new WaitForSeconds(3);
        waveStartingText.gameObject.SetActive(false);
        canSpawn = true;
        Spawn();
    }

    public void ShipDestroyed(GameObject ship)
    {
        currentHPUsed -= ship.GetComponent<Enemy1Collision>().baseHealth;
        activeEnemies.Remove(ship);
        if (currentHPUsed <= 0)
        {
            StartCoroutine(WaveStarting());
        }
    }
}
