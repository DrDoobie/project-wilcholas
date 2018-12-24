using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	[SerializeField] private float health, stamina, mana, statLimit;
	[SerializeField] private Slider healthBar, staminaBar, manaBar;
	
	private void Start () {
		SetValues();
	}

	private void Update () {
		StatController();
	}

	private void SetValues () {
		healthBar.maxValue = statLimit;
		staminaBar.maxValue = statLimit;
		manaBar.maxValue = statLimit;
	}

	private void StatController () {
		healthBar.value = health;
		staminaBar.value = stamina;
		manaBar.value = mana;
	}
}
