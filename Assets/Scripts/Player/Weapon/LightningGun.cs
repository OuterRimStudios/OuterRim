using UnityEngine;
using System.Collections;

public class LightningGun : MonoBehaviour
{
    public GameObject target;
    public GameObject noTarget;
    GameObject player;
    
    bool hasTarget;
    float distance;

    void Start()
    {
        hasTarget = false;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            FindEnemy();
        }
        if (target != null)
        {
            transform.LookAt(target.transform);
        }
        
      
    }

    void FindEnemy()
    {
        target = GameObject.FindGameObjectWithTag("Enemy");
        if (target == null)
        {
            hasTarget = false;

            distance = Vector3.Distance(target.transform.position, player.transform.position);
            if (distance > 5000)
            {
                NoEnemy();
            }
        }
        else if (target.activeInHierarchy)
        {
            target.GetComponent<EnemyState>().isTarget = true;
            hasTarget = true;
        }
        else if (!target.activeInHierarchy)
        {
            hasTarget = false;
        }
    }

    void NoEnemy()
    {

        FindEnemy();
    }
}
