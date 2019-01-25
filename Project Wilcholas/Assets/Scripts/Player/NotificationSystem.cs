using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationSystem : MonoBehaviour {

	[SerializeField] private Text notificationsText;
	[SerializeField] private float displayTime;

	public void Notify (string text) {
		StartCoroutine(Notification(text));
	}

	private IEnumerator Notification (string text) {
		notificationsText.text = "You learned " + text + "!";

		yield return new WaitForSeconds(displayTime);

		notificationsText.text = "";
	}
}
