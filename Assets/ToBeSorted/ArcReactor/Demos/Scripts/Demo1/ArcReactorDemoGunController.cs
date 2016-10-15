using UnityEngine;
using System.Collections;

public class ArcReactorDemoGunController : MonoBehaviour
{
	public ArcReactor_Launcher launcher;

	void Update () 
	{
		//recharge = Mathf.Clamp(recharge - Time.deltaTime,0,1000);
		//Screen.lockCursor = true;
		
		if (Input.GetButtonDown("Fire2"))    // && recharge == 0
        {
			launcher.LaunchRay();
		}
	
	}
}
