using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy {
	float t = 0;
	[SerializeField] float timeToReach;


	IEnumerator MuoviElicottero()
	{
		t = 0;
		Vector3 actualPosition = transform.position;
		Vector3 targetPosition = target.position;
		while (true) {
			t += Time.deltaTime/timeToReach;
			transform.position = new Vector3 (Mathf.Lerp (actualPosition.x, targetPosition.x, t), transform.position.y, Mathf.Lerp (actualPosition.z, targetPosition.z, t));
			yield return 0;
		}


	}

	public override void TakeCheckPoints()
	{
		GameObject aux = GameObject.Find ("CheckPoints");
		checkPoints = new Transform[aux.transform.childCount];
		for (int i = 0; i < checkPoints.Length; i++) {
			checkPoints [i] = aux.transform.GetChild (i);
		}
		target = checkPoints [checkPoints.Length-1];

	}

	public override void Reset()
	{
		health = maxHealth;
		StartCoroutine ("MuoviElicottero");
	}

//	protected override void OnEnable()
//	{
//		Reset ();
//
//	}

}
