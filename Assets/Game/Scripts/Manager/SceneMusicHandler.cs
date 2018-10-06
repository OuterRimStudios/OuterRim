using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneMusicHandler : MonoBehaviour
{

    public List<AudioClip> songList;
    public AudioSource source;

    bool checkingAudio;

    // Use this for initialization
    void Start()
    {
        ChooseRandomSong();
    }

    // Update is called once per frame
    void Update()
    {
        CallCoroutine();
    }

    void ChooseRandomSong()
    {
        source.clip = songList[Random.Range(0, songList.Count)];
        source.Play();
    }

    IEnumerator CheckForAudio()
    {
        if (!checkingAudio)
        {
            checkingAudio = true;
            if (!source.isPlaying)
            {
                ChooseRandomSong();
            }
            yield return new WaitForSeconds(5f);
            checkingAudio = false;
        }
    }

    void CallCoroutine()
    {
        StartCoroutine(CheckForAudio());
    }
}
