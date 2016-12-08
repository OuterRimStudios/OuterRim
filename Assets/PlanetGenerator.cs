using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetGenerator : MonoBehaviour
{
    //Choose a random model
    //Change its size
    //Decide if it has a ring
    //Decide if it has an aseteroid belt
    //Decide if it has moons
    //If it has moons
    //Choose a model
    //Choose its size
    //Choose if it has ring
    //Choose if it has asteroid belt
    //Child to planet

    public GameObject[] planetModels;
    public GameObject asteroidBelt;
    public GameObject[] rings;

    public float planetSpawnMinX;
    public float planetSpawnMaxX;

    public float planetSpawnMinY;
    public float planetSpawnMaxY;

    public float planetSpawnMinZ;
    public float planetSpawnMaxZ;

    public int planetMinSize;
    public int planetMaxSize;

    public int maxAmtOfMoons;

    List<GameObject> activeMoons;

    Vector3 planetSpawn;
    Vector3 planetSize;

    int planetSizeChosen;
    int chosenPlanet;
    int planetAddons;
    int moonCount;

   // int addons; //Does the planet have "addons"
    int chooseMoon;
    float moonSize;
    float ringScale;
    //bool hasRing;
    // bool hasBelt;
    bool hasMoon;
    public static bool planetActive;

    void Update()
    {
        if(!planetActive)
        {
            SpawnPlanet();
        }
    }

    void SpawnPlanet()
    {
        planetActive = true;
        //Chooses a planet, sets it size and location
        planetSpawn = new Vector3(Random.Range(planetSpawnMinX, planetSpawnMaxX), Random.Range(planetSpawnMinY, planetSpawnMaxY), Random.Range(planetSpawnMinZ, planetSpawnMaxZ));  //Choose a random spawn point

        if (planetSpawn.x > 0 && planetSpawn.y > 0 && planetSpawn.z > 0)
            planetSpawn += new Vector3(50000, 50000, 0);
        else
            planetSpawn -= new Vector3(50000, 50000, 0);

        planetSizeChosen = Random.Range(planetMinSize, planetMaxSize);  //Choose a random size
        planetSize = new Vector3(planetSizeChosen, planetSizeChosen, planetSizeChosen); //Assign the planet size
        chosenPlanet = Random.Range(0, planetModels.Length);    //The planet model that was chosen

        //addons = Random.Range(1, 1);
        
        //if(addons == 1)
        //    hasMoon = true;

        //addons = 0;
        
        GameObject planet = Instantiate(planetModels[chosenPlanet], planetSpawn, Quaternion.identity) as GameObject;
        StartCoroutine(Wait());

        //if(hasMoon)
        //{
        //    moonCount = Random.Range(0, maxAmtOfMoons);
        //    activeMoons = new List<GameObject>(moonCount);
        //    for(int j = 0; j < moonCount; j++)
        //    {
        //        print("Calleed");
        //        chooseMoon = Random.Range(0, planetModels.Length);
        //        GameObject moon = Instantiate(planetModels[chooseMoon], planet.transform) as GameObject;
        //        activeMoons.Add(moon);
        //        moon.transform.localScale = new Vector3(moonSize, moonSize, moonSize);
        //        moon.transform.position = planet.transform.localScale * 2;
        //    }

        //    StartCoroutine(MoonScale());
        //}
        //if (hasRing)
        //{
        //    GameObject ring = Instantiate(rings[Random.Range(0, rings.Length)], planet.transform.position, Quaternion.identity) as GameObject;
        //    StartCoroutine(Wait());
        //    ring.transform.SetParent(planet.transform);
        //    ring.transform.localPosition = Vector3.zero;
        //    ring.transform.rotation = new Quaternion(Random.Range(0, 30), Random.Range(0, 30), Random.Range(0, 30),0);

        //    StartCoroutine(Wait());
        //    ringScale = Random.Range(1, 2);
        //    ring.transform.localScale = new Vector3(ringScale, ringScale, ringScale);
        //}
        StartCoroutine(PlanetScale(planet));
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.1f);
    }

    IEnumerator PlanetScale(GameObject _planet)
    {
        for (int i = 0; i < planetSizeChosen; i++)
        {
            if(_planet.transform.localScale.x < planetSizeChosen)
            {
                yield return new WaitForSeconds(.1f);
                _planet.transform.localScale += new Vector3(10, 10, 10);
            }
        }
    }


    //IEnumerator MoonScale()
    //{
    //    foreach(GameObject go in activeMoons)
    //    {   
    //        moonSize = Random.Range(.2f, .8f);
    //        for (int i = 0; i < moonSize; i++)
    //        {
    //            if (go.transform.localScale.x < moonSize)
    //            {
    //                yield return new WaitForSeconds(.1f);
    //                go.transform.localScale += new Vector3(5, 5, 5);
    //            }
    //        }
    //    }
    //}
}
