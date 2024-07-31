using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;
	private AudioSource musicSource, enemySource, machineGunSource, playerSource;
	[SerializeField] AudioClip soundTrack, baseAttack, lost;
	[SerializeField] AudioClip[] enemyDestroy, machineGunClips;

	void Awake()
	{
		instance = this;
		musicSource = gameObject.AddComponent<AudioSource> ();
		musicSource.loop = true;
		musicSource.volume = 1;
		musicSource.clip = soundTrack;
		musicSource.Play ();

		enemySource = gameObject.AddComponent<AudioSource> ();
		enemySource.volume = 0.5f;

		machineGunSource = gameObject.AddComponent<AudioSource> ();
		machineGunSource.volume = 0.5f;

		playerSource = gameObject.AddComponent<AudioSource> ();
		playerSource.volume = 0.5f;
	}

	public void PlayPlayerAttack()
	{
		playerSource.clip = baseAttack;
		playerSource.Play ();
	}

	public void PlayDefeat()
	{
		playerSource.clip = lost;
		playerSource.Play ();
	}

	public void PlayEnemyDestroy()
	{
		enemySource.clip = enemyDestroy [Random.Range (0, enemyDestroy.Length)];
		enemySource.Play ();
	}

	public void PlayTurretClip(string turret)
	{
		Debug.Log (turret);
		switch (turret) {
		case "MachineGun":
			machineGunSource.clip = machineGunClips [Random.Range (0, machineGunClips.Length)];
		break;
		}

		machineGunSource.Play ();
	}
}
