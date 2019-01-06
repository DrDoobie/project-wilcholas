using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour {

	[SerializeField] private float value;
	[Header("Type")]
	[SerializeField] private bool health;
	[SerializeField] private bool stamina;
	[SerializeField] private bool mana;
	private GameObject player;

	private void Awake () {
		player = GameObject.FindWithTag("Player");
	}

	private void OnTriggerEnter (Collider other) {
		if(other.tag == "Player")
		{
			UsePotion();
		}
	}

	private void UsePotion () {
		//Dirt code here, must clean later
		if(health)
		{
			player.GetComponent<PlayerStats>().health += value;

		} else if(stamina) {
			player.GetComponent<PlayerStats>().stamina += value;

		} else if(mana) {
			player.GetComponent<PlayerStats>().mana += value;
		}

		Destroy(this.gameObject);
	}
}
