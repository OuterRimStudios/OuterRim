using UnityEngine;
using System.Collections;

public class TimedObjectDestruct : MonoBehaviour {

    public float timeOut;
    public bool destroy;

	// Update is called once per frame
	void Update () {
        StartCoroutine(WaitTime());
	}

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(timeOut);
        if (destroy)
            Destroy(gameObject);
        else
            gameObject.SetActive(false);
    }
}
