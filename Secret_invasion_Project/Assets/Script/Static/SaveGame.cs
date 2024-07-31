using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveGame {

	public static void SaveCoins(int coins)
	{
		PlayerPrefs.SetInt ("COINS", coins);
		PlayerPrefs.Save ();
	}

	public static int GetCoins()
	{
		return PlayerPrefs.GetInt ("COINS");
	}

	public static void SaveMusicVolume(float volume)
	{
		PlayerPrefs.SetFloat ("MUSIC", volume);
		PlayerPrefs.Save ();
	}

	public static void SaveSoundVolume(float volume)
	{
		PlayerPrefs.SetFloat ("SOUND", volume);
		PlayerPrefs.Save ();
	}

	public static float GetSound()
	{
		return PlayerPrefs.GetFloat ("SOUND");
	}

	public static float GetMusic()
	{
		return PlayerPrefs.GetFloat ("MUSIC");
	}
}
