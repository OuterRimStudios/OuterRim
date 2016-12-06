﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FadeIn : MonoBehaviour
{
    Image image;
    Text text;
    float timer;

    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
        text = transform.FindChild("Tip").GetComponent<Text>();
    }

    void Update()
    {
        if(timer >= .7f)
        {
            StopAllCoroutines();
            timer = 0;
            SceneManager.LoadScene("Game");
        }
    }
    public void StartMyCoroutine()
    {
        StartCoroutine(Fade());
    }
    IEnumerator Fade()
    {
        yield return new WaitUntil(FadingIn);
    }
    bool FadingIn()
    {
        image.color = Color.Lerp(image.color, Color.white, Time.deltaTime * 15f);
        text.color = Color.Lerp(text.color, Color.white, Time.deltaTime * 15f);
        timer += 1 / 60.0f;
        if (image.color == Color.clear)
            return true;
        else
            return false;
    }
}
