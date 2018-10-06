using UnityEngine;
using System.Collections;

public class ActivateShield : MonoBehaviour
{
    GameObject shield;
    GameObject player;
    GameObject gameManager;
    GameObject shieldLevel1Bar;
    GameObject shieldLevel2Bar;
    GameObject shieldLevel3Bar;

    GameObject shieldIcon;

    public bool onCooldown;
    public float shieldCooldown;

    PublicVariableHandler publicVariableHandler;
    Shield shieldScript;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        publicVariableHandler = gameManager.GetComponent<PublicVariableHandler>();
        shield = GetComponent<StoreVariables>().shield;
        shieldScript = shield.GetComponent<Shield>();
        player = GameObject.Find("Player");
    }

    public void ShieldActive()
    {
        player.transform.Find("ShipContainer").Find("Colliders").GetComponent<PlayerCollision>().enabled = false;
        shield.SetActive(true);
    }
}