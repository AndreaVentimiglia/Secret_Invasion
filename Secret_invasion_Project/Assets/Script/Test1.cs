using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour {



	void Update()
	{
		Debug.Log ("Sono un update");
	}

	void LateUpdate()
	{
		Debug.Log ("Sono un late update");
		Debug.Log ("--------------------");
	}

	void FixedUpdate()
	{
		
		Debug.Log ("Sono un fixed update");
		
	}
	

}
