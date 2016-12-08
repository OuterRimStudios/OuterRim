using UnityEngine;
using System.Collections;

public class RandomSkybox : MonoBehaviour
{
    public GameObject[] skyboxes;
    int random;

    void Start()
    {
        random = Random.Range(0, skyboxes.Length);
        skyboxes[random].SetActive(true);
    }
}
