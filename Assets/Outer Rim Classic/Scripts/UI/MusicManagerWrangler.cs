using UnityEngine;
using System.Collections;

public class MusicManagerWrangler : MonoBehaviour
{
    public MusicManager musicManager;

    // Use this for initialization
    void Start()
    {
        musicManager = GameObject.Find("MusicManager").GetComponent<MusicManager>();
    }

    public void SetSong(int value)
    {
        musicManager.ButtonSetSong(value);
    }

    public void SetGenre(int value)
    {
        musicManager.SetGenre(value);
    }
}