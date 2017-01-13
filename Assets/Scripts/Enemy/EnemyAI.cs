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
                case "BaseShip":
                    speed = 300;
                    warpSpeed = 100;
                    break;
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
        playerPosition = new Vector3(Random.Range(player.transform.position.x - 50, player.transform.position.x + 50), Random.Range(player.transform.position.y - 50, player.transform.position.y + 50), player.transform.position.z);

        if(transform.tag != "Carrier")
        {
            if (Vector3.Distance(transform.position, player.transform.position) > 8000)  //If the AI is furthure than 500 meters from the player.
            {
                transform.LookAt(playerPosition);
                transform.Translate(Vector3.forward * warpSpeed * Time.deltaTime);
            }
            else
            {
                transform.LookAt(transform);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, player.transform.position) > 7000)  //If the AI is furthure than 500 meters from the player.
            {
                transform.LookAt(playerPosition);
				transform.Translate(Vector3.forward * (warpSpeed * 10f) * Time.deltaTime);
            }
            else
            {
                transform.LookAt(transform);
				transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }

        if (transform.position.z <= -70)   //If you go to far, shut off.
        {
            if (transform.tag == "Carrier")
            {
                print("too far");
                gameObject.SetActive(false);
            }

            transform.position = gameManager.GetComponent<WaveManager>().ChooseLocation();
        }
    }
}
