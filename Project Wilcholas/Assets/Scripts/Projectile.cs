using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	[SerializeField] private float selfDestructTime;

	void Start () {
		SelfDestruct(selfDestructTime);
	}

	private void SelfDestruct (float value) {
		Destroy(this.gameObject, value);
	}
}
