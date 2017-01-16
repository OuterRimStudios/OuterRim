using UnityEngine;
using System.Collections;
using System.IO;
 
public class AndroidSplitLoadFirstScene : MonoBehaviour
    {

        //Only use in Preloader Scene for android split APK
        private string nextScene = "Game";
        private bool obbisok = false;

        void Update()
        {
            if (Application.dataPath.Contains(".obb") && !obbisok)
            {
                obbisok = true;
                Application.LoadLevel(nextScene);
                // If you need to unpack anything could do it here
                // StartCoroutine(CheckSetUp());
            }
        }
    }
