using UnityEngine;
using System.Collections;

public class WarpIn : MonoBehaviour
{
    public float speed;
    public float warpSpeed;

    void Start()
    {
        StartCoroutine(StartStuffAndThings());
    }

    IEnumerator StartStuffAndThings()
    {
        yield return new WaitUntil(Warp);
        yield return new WaitUntil(MoveTo);
    }

    bool Warp()
    {
        transform.position += Vector3.back * Time.deltaTime * warpSpeed;
        if (transform.position.z <= 50000)
        {
            return true;
        }
        return false;
    }

    bool MoveTo()
    {
        transform.position += Vector3.back * Time.deltaTime * speed;
        if (transform.position.z <= -300000)
        {
            gameObject.SetActive(false);
            return true;
        }
        return false;
    }
}
