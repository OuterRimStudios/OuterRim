using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AchievementButtons : MonoBehaviour
{
    public GameObject subList;
    public RectTransform active;
    public GameObject[] deActivate;
    AchievementWrangler achievementWrangler;

    void Start()
    {
        achievementWrangler = subList.GetComponent<AchievementWrangler>();
    }
	public void DeActivate()
    {
        foreach (GameObject go in deActivate)
        {
            go.SetActive(false);
        }
        achievementWrangler.UpdateScrollRect(active);
    }
}
