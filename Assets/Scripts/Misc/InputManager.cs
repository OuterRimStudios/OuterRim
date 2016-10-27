using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputManager : MonoBehaviour
{
    public Image buttonImg;
    public Sprite xBoxSpriteA;
    public Sprite xBoxSpriteB;
    public Sprite psSpriteX;
    public Sprite psSpriteO;
    public Sprite enter;
    public Sprite esc;
    public Text textBox;

	void Start () {

	}
	
	void Update () {
        if (ControllerDetection.xBox)
        {
            buttonImg.sprite = xBoxSpriteA;
        }
        else if (ControllerDetection.ps)
        {
            buttonImg.sprite = psSpriteX;
        }
        else
        {
            buttonImg.sprite = enter;
        }
	}
}
