using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationSystem : MonoBehaviour {

	[SerializeField] private Text notificationsText;

	public void Notify (string text) {
		StartCoroutine(NotifLoop(text));
	}

	private IEnumerator NotifLoop (string text) {
		notificationsText.text = "You learned " + text + "!";

		yield return new WaitForSeconds(2.5f);

		notificationsText.text = "";
	}
}
