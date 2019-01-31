using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavedData {

	public float health, stamina, mana, statLimit;
	public int coins;

	public SavedData (PlayerStats playerStats)
	{
		health = playerStats.health;
		stamina = playerStats.stamina;
		mana = playerStats.mana;
		statLimit = playerStats.statLimit;
		coins = playerStats.coins;
	} 
}
