using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public GameObject impactEffect;
	[SerializeField] private float damage;
	[SerializeField] private float selfDestructTime;

	void Start () {
		SelfDestruct(selfDestructTime);
	}

	private void SelfDestruct (float value) {
		Destroy(this.gameObject, value);
	}

	private void OnCollisionEnter (Collision col) {
		//If collision with enemy is detected, deal damage
		if(col.gameObject.tag == "Enemy")
		{
			col.gameObject.GetComponent<HealthController>().SubtractHealth(damage);
				Instantiate(impactEffect, transform.position, transform.rotation);
					Destroy(this.gameObject);
		}
	}
}
