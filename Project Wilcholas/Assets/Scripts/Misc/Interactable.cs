using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour {

	private bool inRange, interacted;
	private GameObject gameController;
	public UnityEvent myEvent;

	private void Awake () {
		gameController = GameObject.FindWithTag("GameController");
	}

	private void Update () {
		if((inRange) && (Input.GetButtonDown("Interact")) && (!interacted))
		{
			interacted = true;
			myEvent.Invoke();
		}
	}

	private void OnTriggerEnter (Collider other) {
		if(other.tag == "Player")
		{
			inRange = true;
			gameController.GetComponent<NotificationSystem>().DisplayText("'e'");
		}
	}

	private void OnTriggerExit (Collider other) {
		if(other.tag == "Player")
		{
			inRange = false;
			interacted = false;
			gameController.GetComponent<NotificationSystem>().DisplayText("");
		}
	}
}
