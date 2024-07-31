using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension  {

	public static void Spawn(this Transform trans, Transform spawnPoint)
	{
		trans.position = spawnPoint.position;
		trans.rotation = spawnPoint.rotation;
		trans.gameObject.SetActive (true);

	}

	public static void ChangeTurretColor(this Transform trans,Color c)
	{
		trans.GetChild(0).GetComponent<Renderer>().material.color = c;
		trans.GetChild(1).GetComponent<Renderer> ().material.color = c;

	}
}
