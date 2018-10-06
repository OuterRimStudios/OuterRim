using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using InControl;

public class OuterRimInputManager : MonoBehaviour
{
    public Image selectButtonImg;
    public Image unlockButtonImg;
    public Image colorButtonImg;
    public Image backButtonImg;
    public Image confirmationWindowConfImg;
    public Image confirmationWindowBackImg;
    public Sprite xBoxSpriteA;
    public Sprite xBoxSpriteB;
    public Sprite xBoxSpriteX;
    public Sprite xBoxSpriteY;
    public Sprite psSpriteX;
    public Sprite psSpriteO;
    public Sprite psSpriteSq;
    public Sprite psSpriteTr;
    public Sprite enter;
    public Sprite esc;
    public Sprite eKey;
    public Sprite qKey;
    public Text textBox;

    InputDevice inputDevice;
    public static bool doneLoading;
    public bool isMainMenu;
    public GameObject selectedGameObject;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(selectedGameObject);
    }
    
    void Update()
    {
        inputDevice = InputManager.ActiveDevice;
        if(inputDevice.Action1.WasPressed)
        {
            ExecuteEvents.Execute(EventSystem.current.currentSelectedGameObject, new BaseEventData(EventSystem.current), ExecuteEvents.submitHandler);
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        doneLoading = true;
    }
	
	void LateUpdate ()
    {
        if(isMainMenu)
        {
            if (ControllerDetection.xBox)
            {
                selectButtonImg.sprite = xBoxSpriteA;
                unlockButtonImg.sprite = xBoxSpriteY;
                colorButtonImg.sprite = xBoxSpriteX;
                backButtonImg.sprite = xBoxSpriteB;
                confirmationWindowConfImg.sprite = xBoxSpriteA;
                confirmationWindowBackImg.sprite = xBoxSpriteB;
            }
            else if (ControllerDetection.ps)
            {
                selectButtonImg.sprite = psSpriteX;
                unlockButtonImg.sprite = psSpriteTr;
                colorButtonImg.sprite = psSpriteSq;
                backButtonImg.sprite = psSpriteO;
                confirmationWindowConfImg.sprite = psSpriteX;
                confirmationWindowBackImg.sprite = psSpriteO;
            }
            else
            {
                selectButtonImg.sprite = eKey;
                unlockButtonImg.sprite = eKey;
                colorButtonImg.sprite = qKey;
                backButtonImg.sprite = esc;
                confirmationWindowConfImg.sprite = eKey;
                confirmationWindowBackImg.sprite = esc;
            }
        }
	}
}
