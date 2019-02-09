using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

	[SerializeField] private Component spell;
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
			GameObject.FindWithTag("GameController").GetComponent<NotificationSystem>().Notify("You learned an uknown spell!");
				Destroy(this.gameObject);
	}
}
