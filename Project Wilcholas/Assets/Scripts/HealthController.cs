using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

	[SerializeField] private float health, maxHealth;
	[SerializeField] private Slider healthBar;

	private void Update () {
		UIController();
	}

	private void UIController () {
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
