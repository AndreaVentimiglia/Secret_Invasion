using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKillable<T> 
{
	
	void Kill ();
	void Hit (T damageTaken);

}
