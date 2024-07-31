using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour {
	private bool done=false;
	void Start()
	{
		StartCoroutine (Shoot ());
	}

	IEnumerator Shoot()
	{
		while (true) {
			Debug.Log ("SpawnBullet");
			yield return StartCoroutine(Shoot2());
			Debug.Log ("Fine Shoot");
		}
	}

	IEnumerator Shoot2()
	{
		
			
		yield return new WaitForSeconds (5);
		Debug.Log ("Fine Shoot2");


	}
}
