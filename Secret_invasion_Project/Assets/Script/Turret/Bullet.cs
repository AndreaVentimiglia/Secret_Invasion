using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public void Spawn(Transform spawnPoint)
	{
		
		transform.Spawn (spawnPoint);
	}
}
