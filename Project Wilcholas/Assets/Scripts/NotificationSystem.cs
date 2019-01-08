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
		while(true)
		{
			notificationsText.text = text;

			yield return new WaitForSeconds(1.0f);

			notificationsText.text = "";
		}
	}
}
