using UnityEngine;
using System.Collections;

public class TurnOffAfter : MonoBehaviour
{
	void Awake ()
    {
        StartCoroutine(Despawn());
	}

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
