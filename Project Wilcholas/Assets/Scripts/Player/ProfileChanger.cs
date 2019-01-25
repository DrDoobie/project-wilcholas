using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ProfileChanger : MonoBehaviour {

	[SerializeField] private PostProcessProfile[] profiles;
	[SerializeField] private PostProcessVolume postProcessVolume;
	[SerializeField] private float changeTime;

	private void ChangeProfile (int profile) {
		postProcessVolume.profile = profiles[profile];
	} 

	public void Trip () {
		StartCoroutine(TripEvent());
	}

	private IEnumerator TripEvent () {
		ChangeProfile(1);

		yield return new WaitForSeconds(changeTime);

		ChangeProfile(0);
	}
}
