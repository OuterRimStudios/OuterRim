using UnityEngine;
using System.Collections;

public class RandomSkybox : MonoBehaviour
{
    public GameObject[] skyboxes;
 //   public GameObject sun;
    int random;
   // int isSunOn;

    void Start()
    {
        random = Random.Range(0, skyboxes.Length);
        skyboxes[random].SetActive(true);
    }

    public void NewSkybox()
    {
        foreach(GameObject go in skyboxes)
        {
            if(go.activeInHierarchy)
            {
                GameObject oldSkybox = go;
                go.SetActive(false);

                int newRandom = Random.Range(0, skyboxes.Length);
                while (skyboxes[newRandom] == oldSkybox)
                {
                    newRandom = Random.Range(0, skyboxes.Length);
                    if (skyboxes[newRandom] != oldSkybox)
                    {
                        skyboxes[newRandom].SetActive(true);
                    }
                }
                if (skyboxes[newRandom] != oldSkybox)
                {
                    skyboxes[newRandom].SetActive(true);
                }
            }
        }
    }

}
