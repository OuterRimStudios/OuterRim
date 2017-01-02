using UnityEngine;
using System.Collections;

public class TurnOffAfter : MonoBehaviour
{
	void OnEnable ()
    {
        StartCoroutine(Despawn());
	}

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
