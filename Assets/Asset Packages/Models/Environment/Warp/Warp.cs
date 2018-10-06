using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour
{
    public GameObject warpTunnel;
    public RandomSkybox randomSkybox;
    public WaveManager waveManager;
    Animator warpAnim;
    Vector3 targetScale = new Vector3(20, 20, 40);

    void Start()
    {
        warpAnim = warpTunnel.GetComponent<Animator>();
    }
    
    public IEnumerator BeginWarp()
    {
        DebrisField.canSpawn = false;
        warpTunnel.SetActive(true);
        warpAnim.SetBool("IsWarping", false);
        warpTunnel.transform.localScale = new Vector3(1, 1, 2);

        float overTime = 3;
        float startTime = Time.time;

        while (Time.time < startTime + overTime)
        {
            warpTunnel.transform.localScale = Vector3.Lerp(warpAnim.transform.localScale, targetScale, .5f * Time.deltaTime);
            yield return null;
        }
        warpAnim.SetBool("IsWarping", true);
        yield return new WaitForSeconds(3);
        randomSkybox.NewSkybox();
        yield return new WaitForSeconds(2);
        DebrisField.canSpawn = true;
        waveManager.CanSpawn();
        yield return new WaitForSeconds(2);
        warpTunnel.SetActive(false);
    }
}
