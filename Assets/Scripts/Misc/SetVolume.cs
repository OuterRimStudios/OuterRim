using UnityEngine;
using System.Collections;

public class SetVolume : MonoBehaviour {

    public string volumeType;
    public AudioSource[] sources;

	// Use this for initialization
	void Awake () {
        sources = GetComponents<AudioSource>();
        for (int i = 0; i < sources.Length; i++ )
        {
            sources[i].volume = PlayerPrefs.GetFloat(volumeType)/100.0f;
        }
	}

    void Start()
    {
        sources = GetComponents<AudioSource>();
        for (int i = 0; i < sources.Length; i++)
        {
            sources[i].volume = PlayerPrefs.GetFloat(volumeType) / 100.0f;
        }
    }
}