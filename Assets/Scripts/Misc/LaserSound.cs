using UnityEngine;
using System.Collections;

public class LaserSound : MonoBehaviour
{
    [HideInInspector]
    public AudioSource laserSound;
    GameObject gameManger;
    void Start()
    {
        gameManger = GameObject.Find("GameManager");
        laserSound = GetComponent<AudioSource>();
        laserSound.clip = gameManger.GetComponent<PublicVariableHandler>().laserNoLevelSound;
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
