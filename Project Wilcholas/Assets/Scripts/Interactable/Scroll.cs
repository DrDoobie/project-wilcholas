using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

	[SerializeField] private Spell spell;
	private GameObject player;

	private void Awake () {
		player = GameObject.FindWithTag("Player");
	}

	private void OnTriggerEnter (Collider other) {
		if(other.tag == "Player")
		{
			LearnScroll();
		}
	}

	private void LearnScroll () {
		player.GetComponent<PlayerSpells>().spells.Add(spell);
			GameObject.FindWithTag("GameController").GetComponent<NotificationSystem>().Notify(spell.spellName);
				Destroy(this.gameObject);
	}
}
