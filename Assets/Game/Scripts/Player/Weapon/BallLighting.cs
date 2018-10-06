using UnityEngine;
using System.Collections;

public class BallLighting : MonoBehaviour 
{
    public GameObject lightningRod1;
    public GameObject lightningRod2;
    public GameObject ballLightningSpawn;
    public Vector3 scaleAmount;
    public float coolDown;

    ObjectPooling ballLightningPool;
    BallLightningShoot ballLightningShoot;
    bool isShooting;
    bool isBeingGenerated;

    void Start()
    {
        ballLightningPool = GameObject.Find("BallLightning").GetComponent<ObjectPooling>();
    }
    void Update()
    {
        if(Input.GetAxis("Secondary") != 0)
        {
            GenerateLightningCoroutine();
        }
    }

    IEnumerator GenerateBallLightning()
    {
        if(!isBeingGenerated)
        {
            isBeingGenerated = true;
            lightningRod1.SetActive(true);
            lightningRod2.SetActive(true);
            GameObject obj = ballLightningPool.GetPooledObject();

            if (obj == null)
            {
                yield break;
            }
            obj.transform.position = ballLightningSpawn.transform.position;
            obj.transform.rotation = ballLightningSpawn.transform.rotation;
            obj.GetComponent<BallLightningShoot>().enabled = false;
            obj.transform.parent = ballLightningSpawn.transform;
            obj.SetActive(true);

            obj.transform.GetChild(0).transform.localScale += scaleAmount;
            yield return new WaitForSeconds(.2f);
            obj.transform.GetChild(0).transform.localScale += scaleAmount;
            yield return new WaitForSeconds(.2f);
            obj.transform.GetChild(0).transform.localScale += scaleAmount;
            yield return new WaitForSeconds(.2f);
            obj.transform.GetChild(0).transform.localScale += scaleAmount;
            yield return new WaitForSeconds(.2f);
            obj.transform.GetChild(0).transform.localScale += scaleAmount;
            yield return new WaitForSeconds(.2f);
            obj.transform.GetChild(0).transform.localScale += scaleAmount;
            yield return new WaitForSeconds(.2f);
            obj.transform.GetChild(0).transform.localScale += scaleAmount;
            yield return new WaitForSeconds(.2f);
            obj.transform.GetChild(0).transform.localScale += scaleAmount;
            yield return new WaitForSeconds(.2f);
            obj.transform.GetChild(0).transform.localScale += scaleAmount;
            yield return new WaitForSeconds(.2f);
            obj.transform.GetChild(0).transform.localScale += scaleAmount;
            yield return new WaitForSeconds(.2f);

            lightningRod1.SetActive(false);
            lightningRod2.SetActive(false);
            obj.GetComponent<BallLightningShoot>().enabled = true;
            obj.transform.parent = null;
            yield return new WaitForSeconds(coolDown);
            isBeingGenerated = false;
        }
    }

    void GenerateLightningCoroutine()
    {
        StartCoroutine(GenerateBallLightning());
    }
}
