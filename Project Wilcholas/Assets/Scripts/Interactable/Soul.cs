using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour {

	public string soulNotif;
	private NotificationSystem notificationSystem;
	private PlayerSouls playerSouls;

	private void Awake () {
		notificationSystem = GameObject.FindWithTag("GameController").GetComponent<NotificationSystem>();
		playerSouls = GameObject.FindWithTag("Player").GetComponent<PlayerSouls>();
	}

	private void Absorb () {
		if(!playerSouls.soulReady)
		{
			playerSouls.soulReady = true;
			notificationSystem.Notify(soulNotif);
			Destroy(this.gameObject);
		}
	}

	private void OnTriggerEnter (Collider other) {
		if(other.tag == "Player")
		{
			Absorb();
		}
	}
}
