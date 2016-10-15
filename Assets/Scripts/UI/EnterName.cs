using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnterName : MonoBehaviour {

    public Text textBox;
    public InputField inField;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void EnterHSName()
    {
        PlayerPrefs.SetString("HighScoreName", inField.text);
    }
}
