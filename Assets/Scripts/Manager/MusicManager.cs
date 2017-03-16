using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public string[] genrePaths;
    public AudioSource source;
    List<List<AudioClip>> masterList;
    List<AudioClip> usedSongs;
    int currentGenre;
    int currentSong;
    bool isPlaying;

    InputDevice inputDevice;

    void Awake()
    {
        inputDevice = InputManager.ActiveDevice;
        DontDestroyOnLoad(gameObject);
        if(masterList == null)
        {
            currentGenre = 0;
            masterList = new List<List<AudioClip>>();
            usedSongs = new List<AudioClip>();
            for(int i = 0; i < genrePaths.Length; i++)
            {
                AudioClip[] tempArray = Resources.LoadAll<AudioClip>(genrePaths[i]);
                List<AudioClip> tempList = new List<AudioClip>();
                tempList.AddRange(tempArray);
                masterList.Add(tempList);
            }
            StartCoroutine(Play());
        }
    }
	
	// Update is called once per frame
	void Update () {
        inputDevice = InputManager.ActiveDevice;
	}

    IEnumerator Play()
    {
        if(!isPlaying)
        {
            isPlaying = true;
            source.clip = masterList[currentGenre][currentSong];
            source.Play();
            yield return new WaitUntil(CheckForPlaying);
            isPlaying = false;
            yield return new WaitForSeconds(.05f);
            CallCoroutine("Play");
        }
    }

    bool CheckForPlaying()
    {
        if(inputDevice.LeftBumper.WasPressed || Input.GetButtonDown("Fire4") || (Input.GetKeyDown(KeyCode.Q) && SceneManager.GetActiveScene().buildIndex != 0))
        {
            SetSong(-1);
            return true;
        }

        if(inputDevice.RightBumper.WasPressed || Input.GetButtonDown("Fire5") || (Input.GetKeyDown(KeyCode.E) && SceneManager.GetActiveScene().buildIndex != 0))
        {
            SetSong(1);
            return true;
        }

        if (!source.isPlaying)
        {
            SetSong(1);
        }
        return !source.isPlaying;
    }

    public void SetSong(int value)
    {
        source.Stop();
        if (masterList[currentGenre].Count == 1)
        {
            SetGenre(Random.Range(1, masterList.Count));
            currentSong = 0;
        }
        else
        {
            if (currentSong + value == masterList[currentGenre].Count)
                currentSong = 0;
            else if (currentSong + value < 0)
                currentSong = masterList[currentGenre].Count - 1;
            else
                currentSong += value;
        }
    }

    public void ButtonSetSong(int value)
    {
        source.Stop();
        StopAllCoroutines();
        if (currentSong + value == masterList[currentGenre].Count)
            currentSong = 0;
        else if (currentSong + value < 0)
            currentSong = masterList[currentGenre].Count - 1;
        else
            currentSong += value;

        isPlaying = false;
        CallCoroutine("Play");
    }

    public void SetGenre(int value)
    {
        currentGenre = value;
        source.Stop();
        StopAllCoroutines();
        isPlaying = false;
        CallCoroutine("Play");
    }

    void CallCoroutine(string coroutine)
    {
        StartCoroutine(coroutine);
    }
}