using UnityEngine;
using System.Collections;

public class ToggleOnStart : MonoBehaviour
{
    public GameObject obj;

    void OnEnable () {
        obj.SetActive(false);
	}
}
