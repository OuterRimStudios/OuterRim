using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using InControl;


public class ShipWrangler : MonoBehaviour {

    public GameObject loadScreen;
    public GameObject startMenu;
    public GameObject chooseShipMenu;
    public GameObject startButton;
    public GameObject playButton;
    public GameObject backButton;
    public GameObject unlockButton;
    public GameObject selectButton;
    public GameObject lockedPanel;
    public GameObject[] toggleObjects;

    public RectTransform textMask;

    public Text descriptionText;

    public List<GameObject> ships;

    public int currentShip;
    public bool choosingContainer;
    public bool choosingShip;
    bool hasMoved;
    bool cycling;
    bool transitioning;
    bool transitioned;
    float maskWidth;
    InputDevice inputDevice;

    void Awake()
    {
        gameObject.SetActive(false);
        if (gameObject.name != "ShipContainer")
        {
            if (PlayerPrefs.GetString(gameObject.name + "Ship") != "")
            {
                for (int i = 0; i < ships.Count; i++)
                {
                    if (ships[i].name == PlayerPrefs.GetString(gameObject.name + "Ship")) { currentShip = i; break; }
                    else { currentShip = 0; }
                }
            }
        }
        DisplayShip();
    }

    // Use this for initialization
    void Start()
    {
        maskWidth = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if(DevMode.devMove && Input.GetKeyDown(KeyCode.R) && gameObject.name == "ShipContainer")
        {
            for(int i = 0; i < ships.Count; i++)
            {
                PlayerPrefs.SetString(ships[i].gameObject.name + "Ship", "");
            }
            ResetWranglers();
            DisplayShip();
            print("All ship containers reset");
        }

        inputDevice = InputManager.ActiveDevice;
        if (!Unlock.unlocking)
        {
            DisplayShip();

            if ((inputDevice.LeftStick.Left.WasPressed && !hasMoved) || Input.GetKeyDown(KeyCode.A))      //left  < -.99f
            {
                CallCoroutine("Cycle", "left");
            }
            else if ((inputDevice.LeftStick.Right.WasPressed && !hasMoved) || Input.GetKeyDown(KeyCode.D))  //right
            {
                CallCoroutine("Cycle", "right");
            }
            else if (inputDevice.LeftStick.X == 0)
            {
                hasMoved = false;
            }

            if((inputDevice.Action3.WasReleased || Input.GetKeyDown(KeyCode.Q)) && gameObject.name == "ShipContainer" && ships[currentShip].GetComponent<ShipWrangler>().ships[ships[currentShip].GetComponent<ShipWrangler>().currentShip].GetComponent<ShipUnlocking>().unlocked)
            {
                ShipUnlocking.choosingColor = true;
                choosingContainer = true;
                choosingShip = false;
                SelectContainer();
            }

            if (inputDevice.Action1.WasPressed || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.E))
            {
                if (choosingContainer)
                {
                    SelectContainer();
                }
                else if (choosingShip && gameObject.name == "ShipContainer")
                {
                    ships[currentShip].GetComponent<ShipWrangler>().SelectShip();
                }
                else if(choosingShip && gameObject.name != "ShipContainer")
                {
                    SelectShip();
                }
            }

            if (inputDevice.Action2.WasReleased || Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Escape))
            {
                CancelSelect();
            }
        }
    }

    void CallCoroutine(string coroutine, string arg)
    {
        StartCoroutine(coroutine, arg);
    }

    void CallCoroutine(string coroutine)
    {
        StartCoroutine(coroutine);
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
        if (textMask.rect.width < 600)
        {
            textMask.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 800);
        }
        for (int i = 0; i < ships.Count; i++)
        {
            if (i == currentShip)
            {
                ships[i].SetActive(true);
                if (gameObject.name == "ShipContainer")
                    ChooseShipTracker.currentUnlockedShip = ships[currentShip].GetComponent<ShipWrangler>().ships[ships[currentShip].GetComponent<ShipWrangler>().currentShip];
                else
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

        //foreach (Transform child in ships[currentShip].transform)
        //{
        //    child.GetComponent<ShipUnlocking>().enabled = true;
        //}

        StartCoroutine(Transition());
        descriptionText.text = "Choose your color.";
    }

    public void SelectShip()
    {
        if (ships[currentShip].GetComponent<ShipUnlocking>().unlocked)
        {
            ChooseShipTracker.currentShipName = ships[currentShip].name;
            PlayerPrefs.SetString("Ship", ChooseShipTracker.currentShipName);       //This doesn't really need to grab from the static
            PlayerPrefs.SetString(gameObject.name + "Ship", ships[currentShip].name);
            loadScreen.GetComponent<FadeIn>().TargetScene = "Game";
            loadScreen.GetComponent<FadeIn>().StartMyCoroutine();
        }
    }
    
    public void CancelSelect()
    {
        if (gameObject.name != "ShipContainer")
        {
            //foreach (GameObject go in ships)
            //{
            //    go.GetComponent<ShipUnlocking>().enabled = false;
            //}
            unlockButton.SetActive(false);
            selectButton.SetActive(true);
            lockedPanel.SetActive(false);
            ShipUnlocking.choosingColor = false;
            StartCoroutine(Transition());
            transform.parent.gameObject.GetComponent<ShipWrangler>().enabled = true;
            transform.parent.gameObject.GetComponent<ShipWrangler>().ResetWranglers();
            descriptionText.text = "Choose your ship.";            
        }
        else if (gameObject.name == "ShipContainer")
        {
            textMask.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 800);
            MenuToggle.ToggleMenu(chooseShipMenu, startMenu, startButton);
            ToggleObject.Toggle(toggleObjects);
        }
    }

    public void ResetWranglers()
    {
        choosingShip = true;
        choosingContainer = false;
        for (int i = 0; i < ships.Count; i++)
        {
            ships[i].GetComponent<ShipWrangler>().currentShip = 0;
            ships[i].GetComponent<ShipWrangler>().DisplayShip();
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

    IEnumerator Transition()
    {
        if (!transitioning)
        {
            maskWidth = 1;
            transitioning = true;
            yield return new WaitUntil(MaskTransition);
            transitioning = false;
        }
    }

    bool MaskTransition()
    {
        maskWidth = Mathf.Lerp(maskWidth, 800, Time.deltaTime * 2);
        textMask.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, maskWidth);

        if (textMask.rect.width > 600)
        {
            return true;
        }
        return false;
    }
}

//Condense next/previous selection functions