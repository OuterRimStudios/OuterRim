using UnityEngine;
using System.Collections;

public class DestroyBallLightning : MonoBehaviour
{

    public float timeOut;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(timeOut);
        transform.GetChild(0).localScale = Vector3.zero;
        gameObject.SetActive(false);
    }
}
