using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	[HideInInspector] public bool isAlive;
	public float health = 100.0f, stamina = 100.0f, mana = 100.0f, statLimit = 100.0f, regenSpeed = 0.05f;
	public int coins;
	private Slider healthBar, staminaBar, manaBar;
	
	private void Awake () {
		SetValues();
	}

	private void Update () {
		if(isAlive)
		{
			StatController();
				RegenController();
		}
	}

	private void SetValues () {
		isAlive = true;

		//Set sliders up
		healthBar = GameObject.FindWithTag("HealthBar").GetComponent<Slider>();
			staminaBar = GameObject.FindWithTag("StaminaBar").GetComponent<Slider>();
				manaBar = GameObject.FindWithTag("ManaBar").GetComponent<Slider>();
	}

	private void StatClamp () {
		//Clamp stats
		if(health > statLimit)
		{
			health = statLimit;
		}
			if(stamina > statLimit)
			{
				stamina = statLimit;
			}
				if(mana > statLimit)
				{
					mana = statLimit;
				}
	}

	private void StatController () {
		StatClamp();

		//Set stat bar max values
		healthBar.maxValue = statLimit;
			staminaBar.maxValue = statLimit;
				manaBar.maxValue = statLimit;

		//Update stat bar values
		healthBar.value = health;
			staminaBar.value = stamina;
				manaBar.value = mana;

		//Display coins
		GameObject.FindWithTag("CoinsIndicator").GetComponent<Text>().text = "Coins: " + coins.ToString();

		if(health <= 0)
		{
			Die();
		}
	}

	private void RegenController () {
		//If stat(s) are not full, then regenerate
		if(stamina < statLimit)
		{
			stamina += regenSpeed;
		}
	}
	
	public void Die () {
		isAlive = false;
			Debug.Log("You died!");
	}
}
