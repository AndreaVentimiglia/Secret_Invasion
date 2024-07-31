using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buggy : GroundEnemy {
	
	// Update is called once per frame

	public void ResetHit()
	{
		anim.SetBool ("Hit", false);

	}

	public void SetAnimatorSpeed(float speed_animator)
	{
		anim.SetFloat ("Speed", speed_animator);
	}
}
