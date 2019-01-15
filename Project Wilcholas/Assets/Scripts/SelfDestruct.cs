using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

	[SerializeField] private float destructTime;

	private void Awake () {
		Destroy(this.gameObject, destructTime);
	}
}
