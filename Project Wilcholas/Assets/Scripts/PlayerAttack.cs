using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public GameObject projectile;
	public Transform shootPoint;

	[Header("Variables")]
	[SerializeField] private float shootForce = 25.0f;

	public void Shoot (bool value) {
		//Spawn projectile and add force
		GameObject go = Instantiate(projectile, shootPoint.position, shootPoint.rotation);
		go.GetComponent<Rigidbody>().AddForce((transform.forward * shootForce) * 100.0f);
	}
}