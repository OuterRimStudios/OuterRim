using UnityEngine;
using System.Collections;

public class TimedObjectDestruct : MonoBehaviour {

    public float timeOut;

	// Update is called once per frame
	void Update () {
        StartCoroutine(WaitTime());
	}

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(timeOut);
        gameObject.SetActive(false);
    }
}
