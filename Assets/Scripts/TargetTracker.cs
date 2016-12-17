using UnityEngine;
using System.Collections;

public class TargetTracker : MonoBehaviour
{
    public GameObject target;
    public GameObject arrow;

    void Update()
    {
        PositionArrow();
    }

    void PositionArrow()
    {
        Vector3 v3Pos = Camera.main.WorldToViewportPoint(target.transform.position);
        bool onScreen = v3Pos.z > 0 && v3Pos.x > 0 && v3Pos.x < 1 && v3Pos.y > 0 && v3Pos.y < 1;

        v3Pos.x -= 0.5f;  
        v3Pos.y -= 0.5f;
        v3Pos.z = 0;     

        if (!onScreen && target.activeInHierarchy)
        {
            arrow.SetActive(true);
            float fAngle = Mathf.Atan2(v3Pos.x, v3Pos.y);
            transform.localEulerAngles = new Vector3(0.0f, 0.0f, -fAngle * Mathf.Rad2Deg);

            v3Pos.x = 0.5f * Mathf.Sin(fAngle) + 0.5f;
            v3Pos.y = 0.5f * Mathf.Cos(fAngle) + 0.45f;
            v3Pos.z = Camera.main.nearClipPlane + 0.01f;
            transform.position = Camera.main.ViewportToWorldPoint(v3Pos);
        }
        else
        {
            arrow.SetActive(false);
        }
    }
}

