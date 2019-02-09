using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectile : MonoBehaviour {

	public GameObject prefab;
	public Camera cam;
	public float cost;
	[SerializeField] private float force;

	public void Shoot () {
		GameObject go = Instantiate(prefab, (transform.position + cam.transform.forward), transform.rotation);
		go.GetComponent<Rigidbody>().AddForce((transform.forward * force) * 100.0f);
	}
}