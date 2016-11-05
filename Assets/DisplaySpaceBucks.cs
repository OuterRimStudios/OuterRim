using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplaySpaceBucks : MonoBehaviour {

    public Text textBox;

	// Use this for initialization
	IEnumerator Start () {
        textBox.text = "SpaceBucks: " + PlayerPrefs.GetInt("Currency");
        yield return new WaitForFixedUpdate();
        StartCoroutine(Start());
	}
}
