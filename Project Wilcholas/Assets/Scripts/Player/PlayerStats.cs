using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {

	public float health = 100.0f, stamina = 100.0f, mana = 100.0f, statLimit = 100.0f, regenSpeed = 0.05f;
	public int coins;
	public Slider healthBar, staminaBar, manaBar;
	
	private void Update () {
		StatController();
		StatClamp();
	}

	private void StatController () {
		//Set stat bar max values
		healthBar.maxValue = statLimit;
		staminaBar.maxValue = statLimit;
		manaBar.maxValue = statLimit;

		//Update stat bar values
		healthBar.value = health;
		staminaBar.value = stamina;
		manaBar.value = mana;

		GameObject.FindWithTag("CoinsIndicator").GetComponent<Text>().text = "Coins: " + coins.ToString();
		RegenController();

		if(health <= 0)
		{
			Die();
		}
	}

	private void StatClamp () {
		Mathf.Clamp(health, 0, statLimit);
		Mathf.Clamp(stamina, 0, statLimit);
		Mathf.Clamp(mana, 0, statLimit);
	}

	private void RegenController () {
		if(stamina < statLimit)
		{
			stamina += regenSpeed;
		}
	}

	private void Die () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
