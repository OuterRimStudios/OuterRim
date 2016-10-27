using UnityEngine;
using System.Collections;

public class CauseBlur : MonoBehaviour
{
    UnityStandardAssets.ImageEffects.CameraMotionBlur blur;

    void Start()
    {
        blur = Camera.main.GetComponent<UnityStandardAssets.ImageEffects.CameraMotionBlur>();
    }

    public void StartBlur()
    {
        StartCoroutine(Blur());
    }
    public void EndBlur()
    {
        StartCoroutine(UnBlur());
    }
    IEnumerator Blur()
    {
        for(int i = 0; i < 500; i = i + 10)
        {
            yield return new WaitForSeconds(.01f);
            blur.velocityScale++;
        }
    }

    IEnumerator UnBlur()
    {
        for (int i = 0; i < 500; i = i + 10)
        {
            yield return new WaitForSeconds(.01f);
            blur.velocityScale--;
        }
    }
}
