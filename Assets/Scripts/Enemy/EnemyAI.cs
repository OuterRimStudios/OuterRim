using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public float warpSpeed;
    public float speed;

    private GameObject gameManager;
    private GameObject player;
	Vector3 playerPosition;
    private bool warped;
    private bool inRange;
    WaveHandler waveHandler;
    bool newSpawn;

	void Start ()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        waveHandler = gameManager.GetComponent<WaveHandler>();
		speed = gameManager.GetComponent<PublicVariableHandler> ().enemyAISpeed;
		
        newSpawn = true;
        if (transform.tag == "Carrier")
        {
            speed = 300;
        }
    }
	
	void FixedUpdate ()
    {
        playerPosition = new Vector3(Random.Range(player.transform.position.x - 100, player.transform.position.x + 100), Random.Range(player.transform.position.y - 100, player.transform.position.y + 100), player.transform.position.z);

        if (Vector3.Distance(transform.position, player.transform.position) > 7000)  //If the AI is furthure than 500 meters from the player.
        {
            transform.LookAt(player.transform);
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, warpSpeed);     //Warp In
            warped = true;
        }

        if (warped) //If you are warped in.
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3 (playerPosition.x, playerPosition.y, playerPosition.z - 1000f), 0.25f * Time.deltaTime);    //Move forward

            if (transform.position.z <= -250)   //If you go to far, shut off.
            {
                waveHandler.firstEnemyCount--;
                transform.position = gameManager.GetComponent<WaveManager>().ChooseLocation();
            }
        }
    }
}
