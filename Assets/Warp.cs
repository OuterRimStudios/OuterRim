using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour
{
    public GameObject[] warpTunnels;
    public Light warpLight;
    public Flare[] warpFlares;
    public GameObject warpParticles;
    public RandomSkybox randomSkybox;
    public WaveManager waveManager;

    void OnEnable()
    {
        warpParticles.SetActive(false);
        warpLight.gameObject.SetActive(false);
        foreach (GameObject go in warpTunnels)
        {
            go.SetActive(false);
        }
    }

    public IEnumerator BeginWarp()
    {
        warpParticles.SetActive(true);

        yield return new WaitForSeconds(3f);

        foreach(GameObject go in warpTunnels)
        {
            go.SetActive(true);
        }
        foreach(GameObject go in warpTunnels)
        {
            go.transform.localScale = new Vector3(1, 1, 15);
        }

        yield return new WaitForSeconds(3);

        warpLight.gameObject.SetActive(true);

        for (int i = 0; i < warpFlares.Length; i++)
        {
            warpLight.flare = warpFlares[i];
            yield return new WaitForSeconds(1f);
        }

        randomSkybox.NewSkybox();
        yield return new WaitForSeconds(.5f);

        warpLight.gameObject.SetActive(false);
        foreach(GameObject go in warpTunnels)
        {
            go.SetActive(false);
        }
        yield return new WaitForSeconds(2);
        warpParticles.SetActive(false);

        waveManager.CanSpawn();
    }
}
