﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

	[SerializeField] private bool ai;
	[SerializeField] private float health = 100.0f, value = 1.0f;
	[SerializeField] private Slider healthBar;

	private void Awake () {
		healthBar.maxValue = health;
	}

	private void Update () {
		Controller();
	}

	private void Controller () {
		healthBar.value = health;

		if(health <= 0)
		{
			Die();
		}
	}

	private void Die () {
		if(ai)
		{
			GameObject.FindWithTag("GameController").GetComponent<GameController>().currentAI--;
		}

		GameObject.FindWithTag("Player").GetComponent<PlayerExperience>().AddXp(value);
		Destroy(this.gameObject);
	}

	public void SubtractHealth (float value)
	{
		health -= value;
	}
}
