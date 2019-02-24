using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll : MonoBehaviour {

	[SerializeField] private GameObject spell;
	private NotificationSystem notificationSystem;

	private void Awake () {
		notificationSystem = GameObject.FindWithTag("GameController").GetComponent<NotificationSystem>();
	}

	private void OnTriggerEnter (Collider other) {
		if(other.tag == "Player")
		{
			LearnScroll();
		}
	}

	private void LearnScroll () {
		string text = "You learned " + spell.name + "!";
		notificationSystem.Notify(text);

		spell.GetComponent<Button>().interactable = true;
		Destroy(this.gameObject);
	}
}
