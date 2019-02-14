using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

	[SerializeField] private GameObject spell;
	private GameObject player;
	private NotificationSystem notificationSystem;

	private void Awake () {
		player = GameObject.FindWithTag("Player");
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
		player.GetComponent<PlayerSpells>().LearnSpell(spell);

		Destroy(this.gameObject);
	}
}
