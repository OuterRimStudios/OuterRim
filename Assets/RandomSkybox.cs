using UnityEngine;
using System.Collections;

public class RandomSkybox : MonoBehaviour
{
    public GameObject[] skyboxes;
    public GameObject sun;
    int random;
    int isSunOn;

    void Start()
    {
        isSunOn = 1;
        if(isSunOn == 1)
        {
            sun.SetActive(true);
            sun.transform.position = new Vector3(Random.Range(-30000, 300000), Random.Range(-30000, 30000), 100000);
            if(sun.transform.position.x > -10000 && sun.transform.position.x < 10000 || sun.transform.position.y > -10000 && sun.transform.position.y < 10000)
            {
                sun.transform.position += new Vector3(20000, 20000, 0);
            }
        }
        random = Random.Range(0, skyboxes.Length);
        skyboxes[random].SetActive(true);
    }
}
