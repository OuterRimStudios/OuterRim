using UnityEngine;
using System.Collections;

public class Enemy1Movement : MonoBehaviour {

    public float enemySpeed;
    public GameObject player;
    public float enemyYClamp;
    public float enemyZClamp;
    public float enemyXPos;
    float lerpSpeed;
    GameObject gameManager;

	void Start ()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        enemySpeed = gameManager.GetComponent<PublicVariableHandler>().enemy1Speed;
        enemyZClamp = Random.Range(2f, 5f);
        enemyXPos = Random.Range(-0.5f, 0.5f);
        lerpSpeed = Random.Range(0.5f, 2.5f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {        
        transform.LookAt(player.transform);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -50f, 50f),
                                         Mathf.Clamp(transform.position.y, player.transform.position.y - enemyYClamp, player.transform.position.y + enemyYClamp),
                                         Mathf.Clamp(transform.position.z, player.transform.position.z + enemyZClamp, transform.position.z + (enemyZClamp + 500)));

        if (player.transform.position.z + enemyZClamp < transform.position.z)        //move towards player
        {
            transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);      //new Vector3(0f, 0f, enemySpeed * Time.deltaTime)
        }
        else if (player.transform.position.z + enemyZClamp >= transform.position.z)   //stay back 100 units
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x + enemyXPos, player.transform.position.y, player.transform.position.z), Time.deltaTime * lerpSpeed);
            
        }
    }
}
