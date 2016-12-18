using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsScript : MonoBehaviour {

    public string volumeType;
    public Slider slider;
    public Text sliderText;
    public AudioSource[] sources;

    public bool isMainMenu;

	// Use this for initialization
	void Start () {
        slider.value = PlayerPrefs.GetFloat(volumeType);
        sliderText.text = slider.value.ToString();

        foreach (AudioSource source in sources)
            source.volume = PlayerPrefs.GetFloat(volumeType) / 100.0f;

        sliderText.text = PlayerPrefs.GetFloat(volumeType).ToString();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void UpdateAudioLevel()
    {
        if (sources.Length > 0)
        {
            foreach (AudioSource source in sources)
                source.volume = slider.value/100.0f;
        }

        sliderText.text = slider.value.ToString();
        PlayerPrefs.SetFloat(volumeType, slider.value);
    }
}