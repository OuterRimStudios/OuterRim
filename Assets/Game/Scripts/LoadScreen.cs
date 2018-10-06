using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadScreen : MonoBehaviour
{
    public Sprite[] loadingScreenPictures;
    public string[] tips;

    public Text tipsText;

    public static Sprite picChoosen;
    public static string tipChoosen;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
	void Start ()
    {
        if(picChoosen == null)
        {
            picChoosen = loadingScreenPictures[Random.Range(0, loadingScreenPictures.Length)];
            tipChoosen = tips[Random.Range(0, tips.Length)];
        }
        GetComponent<Image>().sprite = picChoosen;
        tipsText.text = "Tip: " + tipChoosen;
	}
}
