using UnityEngine;
using System.Collections;

public class ActivateLogin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ActivateLoginMenu()
    {
        GameJolt.UI.Manager.Instance.ShowSignIn();
    }
}
