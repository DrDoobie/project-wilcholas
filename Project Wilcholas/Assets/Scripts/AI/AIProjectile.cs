using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIProjectile : MonoBehaviour {

	public GameObject impactEffect;
	public float damage;

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			other.GetComponent<PlayerStats>().health -= damage;
		}

		Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(gameObject, 0.1f);
	}
}
