using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadTargetScreenButton : MonoBehaviour {

    public int sceneToLoad;

    public void LoadSceneNum()
    {
        if (sceneToLoad < 0 || sceneToLoad >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogWarning("Can't load scene num " + sceneToLoad + ". SceneManager only has " + SceneManager.sceneCountInBuildSettings + " scenes in BuildSettings!");
            return;
        }

        LoadingScreenManager.LoadScene(sceneToLoad);
    }

    public void LoadSceneNum(int num)
    {
        if (num < 0 || num >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogWarning("Can't load scene num " + num + ". SceneManager only has " + SceneManager.sceneCountInBuildSettings + " scenes in BuildSettings!");
            return;
        }

        LoadingScreenManager.LoadScene(num);
    }    
}