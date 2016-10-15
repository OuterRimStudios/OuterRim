using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class MenuToggle : MonoBehaviour
{

    public GameObject deactivate;
    public GameObject activate;
    public GameObject nextSelected;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ToggleMenu(GameObject nextSelected)
    {
        deactivate.SetActive(false);
        activate.SetActive(true);
        if (nextSelected != null)
            EventSystem.current.SetSelectedGameObject(nextSelected);
    }

    public void ToggleMenu()
    {
        deactivate.SetActive(false);
        activate.SetActive(true);
        if (nextSelected != null)
            EventSystem.current.SetSelectedGameObject(nextSelected);
    }

    public static void ToggleMenu(GameObject deactivate, GameObject activate, GameObject nextSelected)
    {
        deactivate.SetActive(false);
        activate.SetActive(true);
        if (nextSelected != null)
            EventSystem.current.SetSelectedGameObject(nextSelected);
    }
}