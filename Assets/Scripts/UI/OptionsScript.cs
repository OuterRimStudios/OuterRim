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
        if (PlayerPrefs.GetInt(volumeType + "Changed") != 0)
            slider.value = PlayerPrefs.GetFloat(volumeType);
        else
            slider.value = 50f;

        sliderText.text = slider.value.ToString();

        foreach (AudioSource source in sources)
            source.volume = PlayerPrefs.GetFloat(volumeType) / 100.0f;

        sliderText.text = PlayerPrefs.GetFloat(volumeType).ToString();
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
        PlayerPrefs.SetInt(volumeType + "Changed", 1);
    }
}