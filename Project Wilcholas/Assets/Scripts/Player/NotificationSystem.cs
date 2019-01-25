using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationSystem : MonoBehaviour {

	[SerializeField] private Text notificationsText;
	[SerializeField] private float displayTime = 2.5f;

	public void Notify (string text) {
		StartCoroutine(Notification(text));
	}

	private IEnumerator Notification (string text) {
		notificationsText.text = "You learned " + text + "!";

		yield return new WaitForSeconds(displayTime);

		notificationsText.text = "";
	}
}
