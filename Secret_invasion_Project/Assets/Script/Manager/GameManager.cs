using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

	[SerializeField] Text timerText, waveText;
	float timer=0;
	int wave=1;
	int seconds;

	// Use this for initialization
	void Start () {
		timerText.text = timer.ToString ();
		waveText.text = wave.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		seconds = (int)timer;
		timerText.text = "" + seconds + ":" +timer.ToString().Substring(timer.ToString().IndexOf(".")+1,2);
	}
}
