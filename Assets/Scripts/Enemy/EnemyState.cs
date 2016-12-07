using UnityEngine;
using System.Collections;

public class EnemyState : MonoBehaviour {

    public GameObject lockOn;
    public bool isTarget;
    GameObject player;
    FireMissile fireMissile;
    bool canBeTarget;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        fireMissile =GameObject.Find("MissileNozzle").GetComponent<FireMissile>();
        canBeTarget = true;
	}

    void OnEnable()
    {
        isTarget = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //sets laser target
        if (transform.position.z - player.transform.position.z < 20000 &&
            transform.position.z - player.transform.position.z > 100 &&
            transform.position.y - player.transform.position.y < transform.position.z * .1f &&
            transform.position.y - player.transform.position.y > -transform.position.z * .1f &&
            transform.position.x - player.transform.position.x < transform.position.z * .1f &&
            transform.position.x - player.transform.position.x > -transform.position.z * .1f)
        {
            player.GetComponent<AimAssist>().FoundTarget(gameObject);
        }

        //sets missile target
        if ( transform.position.z - player.transform.position.z < 8000 &&
            transform.position.z - player.transform.position.z > -500 &&
            transform.position.y - player.transform.position.y < 1000 &&
            transform.position.y - player.transform.position.y > -1000 &&
            transform.position.x - player.transform.position.x < 1000 &&
            transform.position.x - player.transform.position.x > -1000)
        {
            if (!fireMissile.targetsInRange.Contains(gameObject))
            {
                fireMissile.targetsInRange.Add(gameObject);
            }
        }
        else
        {
            if(fireMissile.targetsInRange.Contains(gameObject))
            {
                fireMissile.targetsInRange.Remove(gameObject);
            }
        }

	    if(isTarget)
        {
            lockOn.SetActive(true);
            fireMissile.hasTarget = true;
        }
        else
        {
            lockOn.SetActive(false);
        }
	}
}
