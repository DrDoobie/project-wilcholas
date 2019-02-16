using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour {

	public bool inRange, interacted;
	private GameObject gameController;
	public UnityEvent myEvent;

	private void Awake () {
		gameController = GameObject.FindWithTag("GameController");
	}

	private void Update () {
		if((inRange) && (!interacted))
		{
			gameController.GetComponent<NotificationSystem>().DisplayText("'E' to interact");
		
			if(Input.GetButtonDown("Interact"))
			{
				interacted = true;
				myEvent.Invoke();
			}
		}

		if(interacted)
		{
			gameController.GetComponent<NotificationSystem>().DisplayText("");
		}
	}

	private void OnTriggerEnter (Collider other) {
		if(other.tag == "Player")
		{
			inRange = true;
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
