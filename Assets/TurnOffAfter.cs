using UnityEngine;
using System.Collections;

public class TurnOffAfter : MonoBehaviour
{
	IEnumerator Start ()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
	}
}
