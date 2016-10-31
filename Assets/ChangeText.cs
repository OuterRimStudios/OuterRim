using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public Image shipPanel;             //These four variables reference the original objects
    public Text description;
    public Text progress;
    public Text unlocks;

    public Sprite changeShipPanel;      //These four variables change the references above to what ever you set in the inspector.
    public string changeDescription;
    public string changeUnlock;

    [Tooltip("Required amount for achievement unlock.")]
    public int maxValueToUnlock;
    [HideInInspector]
    public int currentValue;

	public void ShowAchievement ()
    {

        currentValue = PlayerPrefs.GetInt("RunningScore");      //Create the running score pref in the achievement manager!!!!!!!!!!!!!!!!!!!!!
        progress.text = currentValue + " / " + maxValueToUnlock;

        shipPanel.sprite = changeShipPanel;
        description.text = changeDescription;
        unlocks.text = "Unlocks: " + changeUnlock;
	}
}
