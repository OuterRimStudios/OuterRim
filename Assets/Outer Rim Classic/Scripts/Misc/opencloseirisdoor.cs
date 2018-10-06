using UnityEngine;
using System.Collections;

public class opencloseirisdoor : MonoBehaviour {


	
	// Update is called once per frame
	void Start ()
	{
		InvokeRepeating ("Door", 1, 100);
	}
	void Door () {
			GetComponent<Animator> ().SetBool ("Open", false); 
		GetComponent<Animator> ().SetBool ("Open", true);
	}
}
