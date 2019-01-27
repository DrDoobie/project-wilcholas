using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	private GameObject gameController;

	private void Awake () {
		gameController = GameObject.FindWithTag("GameController");
	}

	private void OnTriggerEnter (Collider other) {
		if(other.tag == "Player")
		{
			gameController.GetComponent<NotificationSystem>().DisplayText("'e'");
		}
	}

	private void OnTriggerExit (Collider other) {
		if(other.tag == "Player")
		{
			gameController.GetComponent<NotificationSystem>().DisplayText("");
		}
	}
}
