using UnityEngine;
using System.Collections;

public class ActivateShield : MonoBehaviour
{
    GameObject shield;
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
    }
    void ShieldActive()
    {
        shield.SetActive(true);
    }
}