using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

	[SerializeField] private bool ai = false, dropsLoot = false;
	[SerializeField] private Slider healthBar;
	[SerializeField] private float health = 100.0f, value = 1.0f;
	[SerializeField] private GameObject[] lootDrops;

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

	private void DropLoot () {
		int loot = Random.Range(0, lootDrops.Length);
		Instantiate(lootDrops[loot], transform.position, Quaternion.identity);
	}

	private void Die () {
		if(ai)
		{
			GameObject.FindWithTag("GameController").GetComponent<GameController>().currentAI--;
		}

		if(dropsLoot)
		{
			int val = Random.Range(0, 3);

			if(val == 0)
			{
				DropLoot();
			}
		}

		GameObject.FindWithTag("Player").GetComponent<PlayerExperience>().AddXp(value);
		Destroy(this.gameObject);
	}

	public void SubtractHealth (float value)
	{
		health -= value;
	}
}
