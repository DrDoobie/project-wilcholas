using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

	[SerializeField] private float health = 100.0f, maxHealth = 100.0f;
	[SerializeField] private Slider healthBar;

	private void Update () {
		Controller();
	}

	private void Controller () {
		//Set UI values
		healthBar.maxValue = maxHealth;
			healthBar.value = health;

		if(health <= 0)
		{
			Die();
		}
	}

	private void Die () {
		Destroy(this.gameObject);
	}

	public void SubtractHealth (float value)
	{
		health -= value;
	}
}
