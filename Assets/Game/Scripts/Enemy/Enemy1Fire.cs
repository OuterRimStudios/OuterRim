using UnityEngine;
using System.Collections;

public class Enemy1Fire : MonoBehaviour
{
    public float fireFreq;        
    public float minFreq;
    public float maxFreq;
    public string laserPoolName;
    public bool canFire;

    float lastDifficultyIncrease;
    float lastShot;

    ObjectPooling laserObject;
    GameObject gameManager;
    GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
        laserObject = GameObject.Find(laserPoolName).GetComponent<ObjectPooling>();
        gameManager = GameObject.Find("GameManager");
        switch (transform.parent.name)
        {
            case "Enemy1Guns":
                fireFreq = gameManager.GetComponent<PublicVariableHandler>().enemy1FireFreq;
                break;
            case "Enemy2Guns":
                fireFreq = gameManager.GetComponent<PublicVariableHandler>().enemy2FireFreq;
                break;
            case "Enemy3Guns":
                fireFreq = gameManager.GetComponent<PublicVariableHandler>().enemy3FireFreq;
                break;
            case "Enemy4Guns":
                fireFreq = gameManager.GetComponent<PublicVariableHandler>().enemy4FireFreq;
                break;
            case "Enemy5Guns":
                fireFreq = gameManager.GetComponent<PublicVariableHandler>().enemy5FireFreq;
                break;
            case "Enemy6Guns":
                fireFreq = gameManager.GetComponent<PublicVariableHandler>().enemy6FireFreq;
                break;
            case "Enemy7Guns":
                fireFreq = gameManager.GetComponent<PublicVariableHandler>().enemy7FireFreq;
                break;
            case "Enemy8Guns":
                fireFreq = gameManager.GetComponent<PublicVariableHandler>().enemy8FireFreq;
                break;
            case "Enemy9Guns":
                fireFreq = gameManager.GetComponent<PublicVariableHandler>().enemy9FireFreq;
                break;
            case "Enemy10Guns":
                fireFreq = gameManager.GetComponent<PublicVariableHandler>().enemy10FireFreq;
                break;
            case "Enemy11Guns":
                fireFreq = gameManager.GetComponent<PublicVariableHandler>().enemy11FireFreq;
                break;
            case "Enemy12Guns":
                fireFreq = gameManager.GetComponent<PublicVariableHandler>().enemy12FireFreq;
                break;
        }
    }

	// Update is called once per frame
	void Update () {
        if (canFire)
        {
            if (Time.time > lastShot + fireFreq)
            {
                Fire();
            }
        }
    }

    void Fire()
    {
        lastShot = Time.time;
        GameObject obj = laserObject.GetPooledObject();

        if (obj == null)
        {
            return;
        }

        if (transform.position.z >= player.transform.position.z + 500)
            transform.LookAt(player.transform);


        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
    }
}
