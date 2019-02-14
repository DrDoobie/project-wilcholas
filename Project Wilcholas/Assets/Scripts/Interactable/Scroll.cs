using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

	[SerializeField] private GameObject spell;
	private PlayerSpells playerSpells;
	private NotificationSystem notificationSystem;

	private void Awake () {
		playerSpells = GameObject.FindWithTag("SpellContainer").GetComponent<PlayerSpells>();
		notificationSystem = GameObject.FindWithTag("GameController").GetComponent<NotificationSystem>();
	}

	private void OnTriggerEnter (Collider other) {
		if(other.tag == "Player")
		{
			LearnScroll();
		}
	}

	private void LearnScroll () {
		notificationSystem.Notify(spell.name);
		playerSpells.GetComponent<PlayerSpells>().LearnSpell(spell);

		Destroy(this.gameObject);
	}
}
