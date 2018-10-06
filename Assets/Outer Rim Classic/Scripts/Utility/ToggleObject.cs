using UnityEngine;
using System.Collections;

public class ToggleObject : MonoBehaviour
{

    public GameObject[] objects;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Toggle()
    {
        foreach(GameObject obj in objects)
        {
            obj.SetActive(!obj.activeInHierarchy);
        }        
    }

    public static void Toggle(GameObject[] objects)
    {
        foreach(GameObject obj in objects)
        {
            obj.SetActive(!obj.activeInHierarchy);
        }
    }
}