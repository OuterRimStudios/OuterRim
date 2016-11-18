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
        if (Input.GetButtonDown("Fire2") && hasTarget)
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
        if(target == null)
        {
            FindEnemy();
            hasTarget = false;
        }
        else if (target != null)
        {
            hasTarget = true;

            distance = Vector3.Distance(target.transform.position, player.transform.position);
            if (distance > 5000)
            {
                FindEnemy();
            }
        }
        else if (!target.activeInHierarchy)
        {
            FindEnemy();
            hasTarget = false;
        }
        else if (target.activeInHierarchy)
        {
            target.GetComponent<EnemyState>().isTarget = true;
            hasTarget = true;
        }
    }
}
