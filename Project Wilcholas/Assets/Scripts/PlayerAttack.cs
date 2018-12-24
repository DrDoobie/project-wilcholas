using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public GameObject projectile;
	public Transform shootPoint;
	[SerializeField] private float shootForce = 25.0f;

	private void Update () {
		ShootController();
	}

	private void ShootController () {
		if(Input.GetButtonDown("Fire1"))
		{
			BasicAttack();
		}
	}

	private void BasicAttack () {
		//Spawn projectile and add force
		GameObject go = Instantiate(projectile, shootPoint.position, shootPoint.rotation);
		go.GetComponent<Rigidbody>().AddForce((transform.forward * shootForce) * 100.0f);
	}
}