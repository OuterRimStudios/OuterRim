using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class ShipWrangler : MonoBehaviour {

    public GameObject startMenu;
    public GameObject chooseShipMenu;
    public GameObject startButton;
    public GameObject playButton;
    public GameObject backButton;
    public GameObject lights;
    public GameObject shipLight;

    public Text descriptionText;
    public Text selectText;

    public List<GameObject> ships;

    public int currentShip;
    public bool choosingContainer;
    public bool choosingShip;
    bool hasMoved;
    bool cycling;

    // Use this for initialization
    void Start()
    {
        //Transform[] children;
        //children = transform.GetComponentsInChildren<Transform>();
        //foreach (Transform t in children)
        //{
        //    if (t.tag == "ShipWrangler")
        //    {
        //        ships.Add(t.gameObject);
        //        t.gameObject.SetActive(false);
        //    }
        //}       
    }

    // Update is called once per frame
    void Update()
    {
        DisplayShip();

        if ((Input.GetAxis("Horizontal") < -.99f && !hasMoved) || Input.GetKeyDown(KeyCode.A))      //left
        {
            CallCoroutine("left");
        }
        else if ((Input.GetAxis("Horizontal") > .99f && !hasMoved) || Input.GetKeyDown(KeyCode.D))  //right
        {
            CallCoroutine("right");
        }
        else if (Input.GetAxis("Horizontal") > -.09f && Input.GetAxis("Horizontal") < .09f)
        {
            hasMoved = false;
        }

        if (Input.GetButtonDown("Submit"))
        {
            if (choosingContainer)
            {
                SelectContainer();
            }
            else if (choosingShip)
            {
                SelectShip();
            }
        }

        if (Input.GetButtonDown("Cancel"))
        {
            CancelSelect();
        }
    }

    void CallCoroutine(string direction)
    {
        StartCoroutine(Cycle(direction));
    }

    public GameObject CurrentShip
    {
        get { return ships[currentShip]; }
        set { ships[currentShip] = value; }
    }

    public void NextSelection()
    {
        if (currentShip == ships.Count - 1)
        {
            currentShip = 0;
        }
        else
        {
            currentShip++;
        }
    }

    public void PreviousSelection()
    {
        if (currentShip == 0)
        {
            currentShip = ships.Count - 1;
        }
        else
        {
            currentShip--;
        }
    }

    void DisplayShip()
    {
        for (int i = 0; i < ships.Count; i++)
        {
            if (i == currentShip)
            {
                ships[i].SetActive(true);
                ChooseShipTracker.currentUnlockedShip = ships[i];
            }
            else
            {
                ships[i].SetActive(false);
            }
        }
    }

    void SelectContainer()
    {
        enabled = false;

        for (int i = 0; i < ships.Count; i++)
        {
            ships[i].GetComponent<ShipWrangler>().enabled = true;
        }

        playButton.SetActive(false);
        backButton.SetActive(false);
        descriptionText.text = "Choose your color.";
        selectText.text = "Press       to select your color";
    }

    void SelectShip()
    {
        if (ships[currentShip].GetComponent<ShipUnlocking>().unlocked)
        {
            ChooseShipTracker.currentShipName = ships[currentShip].name;
            playButton.SetActive(true);
            backButton.SetActive(true);
            EventSystem.current.SetSelectedGameObject(playButton);
        }
    }

    public void CancelSelect()
    {
        if (gameObject.name != "ShipContainer")
        {
            transform.parent.gameObject.GetComponent<ShipWrangler>().enabled = true;
            transform.parent.gameObject.GetComponent<ShipWrangler>().ResetWranglers();
            descriptionText.text = "Choose your ship.";
            selectText.text = "Press       to select your ship";
        }
        else if (gameObject.name == "ShipContainer")
        {
            MenuToggle.ToggleMenu(chooseShipMenu, startMenu, startButton);
            ToggleObject.Toggle(lights, shipLight, gameObject);
        }

        playButton.SetActive(false);
        backButton.SetActive(false);
    }

    public void ResetWranglers()
    {
        for (int i = 0; i < ships.Count; i++)
        {
            ships[i].GetComponent<ShipWrangler>().enabled = false;
        }
    }

    IEnumerator Cycle(string direction)
    {
        if (!cycling)
        {
            cycling = true;
            if (direction == "left")
            {
                hasMoved = true;
                PreviousSelection();
            }
            else if (direction == "right")
            {
                hasMoved = true;
                NextSelection();
            }

            yield return new WaitForSeconds(.25f);
            cycling = false;
        }
    }
}

//Condense next/previous selection functions