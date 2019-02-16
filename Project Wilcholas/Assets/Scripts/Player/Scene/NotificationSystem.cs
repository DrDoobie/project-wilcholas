using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationSystem : MonoBehaviour {

	private bool isNotifying;
	[SerializeField] private Text notificationsText;
	[SerializeField] private float displayTime = 2.5f;

	public void Notify (string text) {
		StartCoroutine(Notification(text));
	}

	public void DisplayText (string text) {
		if(!isNotifying)
		{
			notificationsText.text = text;
		}
	}

	private IEnumerator Notification (string text) {
		isNotifying = true;
		notificationsText.text = "";

		foreach(char letter in text.ToCharArray())
		{
			notificationsText.text += letter;
			yield return null;
		}

		yield return new WaitForSeconds(displayTime);

		isNotifying = false;
		notificationsText.text = "";
	}
}
