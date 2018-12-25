using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public GameObject projectile;
	[SerializeField] private float basicAttackForce = 25.0f, attack1Cost = 10.0f;

	private void Update () {
		AttackController();
	}

	private void AttackController () {
		if(Input.GetButtonDown("Fire1"))
		{
			BasicAttack(attack1Cost);
		}
	}

	private void BasicAttack (float value) {
		if(GetComponent<PlayerStats>().mana >= attack1Cost)
		{
			//Spawn projectile and add force
			GameObject go = Instantiate(projectile, (transform.position + Camera.main.transform.forward), (transform.rotation));
			go.GetComponent<Rigidbody>().AddForce((transform.forward * basicAttackForce) * 100.0f);

			GetComponent<PlayerStats>().mana -= value;
		}
	}
}