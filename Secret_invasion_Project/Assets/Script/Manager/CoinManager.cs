using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinManager : MonoBehaviour {


	public static CoinManager instance;
	[SerializeField] Text coinText;
	[SerializeField] int coins;
	// Use this for initialization
	void Awake () {
		instance = this;
	}

	void Start()
	{
		coins = SaveGame.GetCoins ();
		coinText.text = coins.ToString ();

	}
	
	public void AddCoins(int coinsToAdd)
	{
		coins += coinsToAdd;
		coinText.text = coins.ToString ();
	}

	public void SaveCoins()
	{
		SaveGame.SaveCoins (coins);
	}

    public bool RemoveMoney(int moneyToRemove)
    {
        if (moneyToRemove > coins)
            return false;
        coins -= moneyToRemove;
        coinText.text = coins.ToString();
        return true;
    }
}
