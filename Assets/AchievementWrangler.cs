using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AchievementWrangler : MonoBehaviour
{
    public RectTransform[] subAchieves;
    RectTransform active;
    ScrollRect scrollRect;

    void Awake()
    {
        scrollRect = GetComponent<ScrollRect>();
    }

    public void UpdateScrollRect(RectTransform newContent)
    {
        if(newContent != null || scrollRect != null || scrollRect.content != null)
        {
            scrollRect.content = newContent;
        }
    }
}
