using UnityEngine;
using System.Collections;

public class LaserSound : MonoBehaviour
{
    [HideInInspector]
    public AudioSource laserSound;
    AudioClip normalLaserSound;
    AudioClip dualLaserSound;
    GameObject gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        laserSound = gameManager.transform.FindChild("GunSource").GetComponent<AudioSource>();
        normalLaserSound = gameManager.GetComponent<PublicVariableHandler>().normalLaserSound;
        if (transform.tag == "PowerUpLasers" || transform.tag == "PodLeft" || transform.tag == "PodRight")
        {
            dualLaserSound = gameManager.GetComponent<PublicVariableHandler>().dualLaserSound;
            laserSound.clip = dualLaserSound;
        }
        else
        {
            laserSound.clip = normalLaserSound;
        }
    }

    void OnEnable()
    {
        gameManager = GameObject.Find("GameManager");
        laserSound = gameManager.transform.FindChild("GunSource").GetComponent<AudioSource>();
        normalLaserSound = gameManager.GetComponent<PublicVariableHandler>().normalLaserSound;
        if (transform.tag == "PowerUpLasers" || transform.tag == "PodLeft" || transform.tag == "PodRight")
        {
            dualLaserSound = gameManager.GetComponent<PublicVariableHandler>().dualLaserSound;
            laserSound.clip = dualLaserSound;
        }
        else
        {
            laserSound.clip = normalLaserSound;
        }
    }

    public void Shooting()
    {
        laserSound.Play();
    }

    public void LevelChange()
    {
        laserSound.clip = normalLaserSound;
    }
}
