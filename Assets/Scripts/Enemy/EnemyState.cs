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
        if(Vector3.Distance(new Vector3 (0,0,transform.position.z), new Vector3(0,0,player.transform.position.z)) < 8000 &&
            Vector3.Distance(new Vector3(0, 0, transform.position.z), new Vector3(0, 0, player.transform.position.z)) > -500 &&
            Vector3.Distance(new Vector3(0, transform.position.y, 0), new Vector3(0, player.transform.position.y, 0)) < 1000 &&
            Vector3.Distance(new Vector3(0, transform.position.y, 0), new Vector3(0, player.transform.position.y, 0)) > -1000 &&
             Vector3.Distance(new Vector3(transform.position.x, 0, 0), new Vector3(player.transform.position.x, 0, 0)) < 1000 &&
             Vector3.Distance(new Vector3(transform.position.x, 0, 0), new Vector3(player.transform.position.x, 0, 0)) > -1000)
        {
            if (!fireMissile.targetsInRange.Contains(gameObject))
            {
                fireMissile.targetsInRange.Add(gameObject);
                print("is this calling?");
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
