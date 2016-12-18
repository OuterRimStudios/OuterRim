using UnityEngine;
using System.Collections;

public class LaserSound : MonoBehaviour
{
    [HideInInspector]
    public AudioSource laserSound;
    GameObject gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        laserSound = gameManager.transform.FindChild("GunSource").GetComponent<AudioSource>();
        laserSound.clip = gameManager.GetComponent<PublicVariableHandler>().laserNoLevelSound;
    }

    public void Shooting()
    {
        laserSound.Play();
    }

    public void LevelChange(AudioClip audioClip)
    {
        laserSound.clip = audioClip;
    }
}
