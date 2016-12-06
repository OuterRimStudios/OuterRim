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
    bool newSpawn;
    PublicVariableHandler publicVariableHandler;

	void Start ()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager");
        publicVariableHandler = gameManager.GetComponent<PublicVariableHandler>();
		
        newSpawn = true;

        if (transform.tag == "Enemy")
        {
            switch (transform.name)
            {
                case "Enemy 01":
                    speed = publicVariableHandler.enemy1Speed;
                    break;
                case "Enemy 02":
                    speed = publicVariableHandler.enemy2Speed;
                    break;
                case "Enemy 03":
                    speed = publicVariableHandler.enemy3Speed;
                    break;
                case "Enemy 04":
                    speed = publicVariableHandler.enemy4Speed;
                    break;
                case "Enemy 05":
                    speed = publicVariableHandler.enemy5Speed;
                    break;
                case "Enemy 06":
                    speed = publicVariableHandler.enemy6Speed;
                    break;
                case "Enemy 07":
                    speed = publicVariableHandler.enemy7Speed;
                    break;
                case "Enemy 08":
                    speed = publicVariableHandler.enemy8Speed;
                    break;
                case "Enemy 09":
                    speed = publicVariableHandler.enemy9Speed;
                    break;
                case "Enemy 10":
                    speed = publicVariableHandler.enemy10Speed;
                    break;
                case "Enemy 11":
                    speed = publicVariableHandler.enemy11Speed;
                    break;
                case "Enemy 12":
                    speed = publicVariableHandler.enemy12Speed;
                    break;
            }
        }
        else if (transform.tag == "Carrier")
        {
            speed = publicVariableHandler.carrierSpeed;
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
            if(tag == "Carrier")
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(playerPosition.x, playerPosition.y, playerPosition.z - 1000f), 0.05f * Time.deltaTime);
            }
            else
            transform.position = Vector3.Lerp(transform.position, new Vector3 (playerPosition.x, playerPosition.y, playerPosition.z - 1000f), 0.25f * Time.deltaTime);    //Move forward

            if (transform.position.z <= -250)   //If you go to far, shut off.
            {
                if (transform.tag == "Carrier")
                {
                    gameObject.SetActive(false);
                }

                transform.position = gameManager.GetComponent<WaveManager>().ChooseLocation();
            }
        }
    }
}
