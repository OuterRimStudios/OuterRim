using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour 
{
 		
		
public Animator anim;
	
	void Start()
	{
		anim = GetComponent<Animator> ();
	}
	void Update()
	{
		if (Input.GetKeyDown ("a")) 
		{
			anim.SetBool("StrafeLeft", true);
			anim.SetBool("StrafeRight", false);
			anim.SetBool("Idle", false);
		} 
		
		 else if(Input.GetKeyDown("d"))
		{
			anim.SetBool("StrafeLeft", false);
			anim.SetBool("StrafeRight", true);
			anim.SetBool("Idle", false);
		}
		else
		{
			anim.SetBool("StrafeLeft", false);
			anim.SetBool("StrafeRight", false);
			anim.SetBool("Idle", true);
		}
		
	}

}

