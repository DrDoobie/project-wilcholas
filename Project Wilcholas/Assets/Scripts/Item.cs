using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	[SerializeField] private bool inventoryItem;
	[Header("Values")]
	[SerializeField] private bool health;
	[SerializeField] private bool stamina;
	[SerializeField] private bool mana;
	[SerializeField] private float value;
	private GameObject player;

	private void Awake () {
		player = GameObject.FindWithTag("Player");
	}

	private void OnTriggerEnter (Collider other) {
		if((!inventoryItem) && (other.tag == "Player"))
		{
			UseItem();
		}
	}

	private void UseItem () {
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
