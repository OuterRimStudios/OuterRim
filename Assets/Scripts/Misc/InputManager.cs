using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputManager : MonoBehaviour
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

	void Start () {

	}
	
	void LateUpdate () {
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
            selectButtonImg.sprite = enter;
            unlockButtonImg.sprite = eKey;
            colorButtonImg.sprite = qKey;
            backButtonImg.sprite = esc;
            confirmationWindowConfImg.sprite = enter;
            confirmationWindowBackImg.sprite = esc;
        }
	}
}
