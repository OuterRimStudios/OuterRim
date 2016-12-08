using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class AuthenticationScript : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
        //Environment.CurrentDirectory;
        //DirectoryInfo info = new DirectoryInfo(".");
        //print("Directory info: " + Environment.CurrentDirectory);
        //Dictionary<string, string> headers = new Dictionary<string, string>()
        //{
        //    {"Authorization", "TfV3Oj0BL86ENr60KGbNFTyRfmP9vMhfMEK72M25" }
        //};
        string apiKey = Environment.GetEnvironmentVariable("Environment.CurrentDirectory.ITCHIO_API_KEY");
        WWWForm form = new WWWForm();
        form.headers.Add("Authorization", apiKey);
        WWW link = new WWW("https://itch.io/api/1/jwt/me", form);//  https://itch.io/api/1/jwt/me  https://itch.io/api/1/KEY/outer-rim/81890/download_keys  https://itch.io/api/1/O1w0cg26gl8rvRQuL53yrq4zogOtkfoFrlC1HKzv/my-games  https://itch.io/api/1/ev27661tyLcG7FuJfTaHmXi1phMBHq5krfX6ZT9S/game/81890/download_keys
        yield return link;
        Debug.LogError(form.headers.ContainsKey("Authorization"));
        Debug.LogError(link.text);

        //UnityWebRequest www = new UnityWebRequest("https://itch.io/api/1/ev27661tyLcG7FuJfTaHmXi1phMBHq5krfX6ZT9S/game/81890/download_keys");
        //www.SetRequestHeader("Authorization", "TfV3Oj0BL86ENr60KGbNFTyRfmP9vMhfMEK72M25");
        //yield return www;
        ////print(www.GetRequestHeader("Authorization"));
        //print(www.downloadHandler.text);
        //UDo9wZjlKhB4wdDqjwS6I5029281YBOWO4wky1S4
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}

public class Authenticate : MonoBehaviour
{
    //public string 

}
