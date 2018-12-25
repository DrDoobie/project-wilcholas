using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	[HideInInspector] public bool isAlive;
	[SerializeField] private float health = 100.0f, stamina = 100.0f, mana = 100.0f, statLimit = 100.0f;
	private Slider healthBar, staminaBar, manaBar;
	
	private void Awake () {
		SetValues();
	}

	private void Update () {
		if(isAlive)
		{
			StatController();
		}
	}

	private void SetValues () {
		isAlive = true;

		//Set sliders up
		healthBar = GameObject.FindWithTag("HealthBar").GetComponent<Slider>();
		staminaBar = GameObject.FindWithTag("StaminaBar").GetComponent<Slider>();
		manaBar = GameObject.FindWithTag("ManaBar").GetComponent<Slider>();
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

		if(health <= 0)
		{
			Die();
		}
	}

	public void Die () {
		Debug.Log("You died!");
		isAlive = false;
	}
}
