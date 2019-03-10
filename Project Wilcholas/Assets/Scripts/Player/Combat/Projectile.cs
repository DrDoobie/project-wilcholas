using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour {

	public bool enemyProjectile;
	public GameObject impactEffect, dmgPopup;
	private float damage;
	[SerializeField] private float minDamg = 7.0f, maxDamg = 12.0f;
	[SerializeField] private float selfDestructTime;

	void Start () {
		SelfDestruct(selfDestructTime);
		damage = Random.Range(minDamg, maxDamg);
	}

	private void SelfDestruct (float value) {
		Destroy(this.gameObject, value);
	}

	private void DamagePopup () {
		GameObject go = Instantiate(dmgPopup, transform.position, transform.rotation);
		go.transform.GetChild(0).GetComponent<Text>().text = "-" + ((int)damage).ToString();
		Destroy(go, 0.75f);
	}

	private void OnCollisionEnter (Collision col) {
		//If collision with enemy is detected, deal damage
		if(col.gameObject.tag == "Enemy" && (!enemyProjectile))
		{
			col.gameObject.GetComponent<HealthController>().SubtractHealth(damage);
			col.gameObject.GetComponent<AIMotor>().agro = true;
			DamagePopup();

		} else if(col.gameObject.tag == "Player" && (enemyProjectile)) {
			col.gameObject.GetComponent<PlayerStats>().health -= damage;
		}

		Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(this.gameObject);
	}
}
