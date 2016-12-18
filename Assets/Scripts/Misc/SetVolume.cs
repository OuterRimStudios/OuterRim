using UnityEngine;
using System.Collections;

public class SetVolume : MonoBehaviour {

    public string volumeType;
    AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        source.volume = PlayerPrefs.GetFloat(volumeType);
	}
}
