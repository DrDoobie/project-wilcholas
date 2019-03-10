using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIProjectile : MonoBehaviour {

	public float damage;

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			other.GetComponent<PlayerStats>().health -= damage;
			Destroy(gameObject, 0.1f);
		}
	}
}
