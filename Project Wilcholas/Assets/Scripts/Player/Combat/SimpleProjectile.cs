using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleProjectile : MonoBehaviour {

	public GameObject prefab;
	private Camera cam;
	private GameObject player;
	[SerializeField] private float force = 20.0f, cost = 5.0f;

	private void Awake () {
		cam = Camera.main;
		player = GameObject.FindWithTag("Player");
	}

	private void Update () {
		if((Input.GetButtonDown("Fire1")) && (player.GetComponent<PlayerStats>().mana >= cost))
		{
			Shoot();
		}
	}

	public void Shoot () {
		GameObject go = Instantiate(prefab, (transform.position + cam.transform.forward), transform.rotation);
		go.GetComponent<Rigidbody>().AddForce((transform.forward * force) * 100.0f);

		player.GetComponent<PlayerStats>().mana -= cost;
	}
}