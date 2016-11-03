using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputManager : MonoBehaviour
{
    public Image selectButtonImg;
    public Image unlockButtonImg;
    public Image backButtonImg;
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
    public Text textBox;

	void Start () {

	}
	
	void Update () {
        if (ControllerDetection.xBox)
        {
            selectButtonImg.sprite = xBoxSpriteA;
            unlockButtonImg.sprite = xBoxSpriteY;
            backButtonImg.sprite = xBoxSpriteB;
        }
        else if (ControllerDetection.ps)
        {
            selectButtonImg.sprite = psSpriteX;
            unlockButtonImg.sprite = psSpriteTr;
            backButtonImg.sprite = psSpriteO;
        }
        else
        {
            selectButtonImg.sprite = enter;
            unlockButtonImg.sprite = eKey;
            backButtonImg.sprite = esc;
        }
	}
}
