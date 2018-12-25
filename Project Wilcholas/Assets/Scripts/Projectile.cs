using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	[SerializeField] private float damage;
	[SerializeField] private float selfDestructTime;

	void Start () {
		SelfDestruct(selfDestructTime);
	}

	private void SelfDestruct (float value) {
		Destroy(this.gameObject, value);
	}

	private void OnCollisionEnter (Collision col) {
		if(col.gameObject.tag == "Enemy")
		{
			col.gameObject.GetComponent<HealthController>().SubtractHealth(damage);
			Destroy(this.gameObject);
		}
	}
}
