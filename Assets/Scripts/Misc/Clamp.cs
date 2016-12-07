using UnityEngine;
using System.Collections;

public class Clamp : MonoBehaviour {

    public GameObject warningText;
    public GameObject particleCloud;
    public float waitTime = 1f;
    bool killingPlayer;
    GameObject parent;
        
    void Start()
    {

    }
    void OnTriggerEnter(Collider col)
    {
        if (gameObject.tag == "InnerClamp")
        {
            if (col.name == "Colliders")
            {
                warningText.SetActive(true);

                particleCloud.SetActive(true);
            }
        }        
    }

    void OnTriggerStay(Collider col)
    {
        if (gameObject.tag == "OuterClamp")
        {
            if (col.name == "Colliders")
            {
                warningText.SetActive(true);
                StartCoroutine(KillPlayer(col.gameObject));               
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (gameObject.tag == "InnerClamp")
        {
            if (col.name == "Colliders")
            {
                warningText.SetActive(false);
                particleCloud.SetActive(false);
            }
        }
    }

    IEnumerator KillPlayer(GameObject player)
    {
        if (!killingPlayer)
        {
            killingPlayer = true;
            player.GetComponent<PlayerCollision>().TakeDamage(1);
            yield return new WaitForSeconds(waitTime);
            killingPlayer = false;
        }
    }
}