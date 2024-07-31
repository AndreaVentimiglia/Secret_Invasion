using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	public static PlayerManager instance;
	[SerializeField] float health;
	// Use this for initialization

	void Awake () {
		instance = this;
	}

	public void TakeDamage(float damage)
	{
		health -= damage;
		SoundManager.instance.PlayPlayerAttack ();
		if (health <= 0) {
			SoundManager.instance.PlayDefeat ();
			CoinManager.instance.SaveCoins ();
			Time.timeScale = 0;
		}
	}

}
