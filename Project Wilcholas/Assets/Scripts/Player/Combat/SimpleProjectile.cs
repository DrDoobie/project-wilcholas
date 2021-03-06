﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleProjectile : MonoBehaviour {

	public GameObject prefab;
	private Camera cam;
	private GameObject player;
	private GameController gameController;
	[SerializeField] private float force = 20.0f, cost = 5.0f;

	private void Awake () {
		cam = Camera.main;
		player = GameObject.FindWithTag("Player");
		gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
	}

	private void Update () {
		if((Input.GetButtonDown("Fire1")) && (!gameController.isPaused))
		{
			Shoot();
		}
	}

	public void Shoot () {
		if(player.GetComponent<PlayerStats>().mana >= cost)
		{
			GameObject go = Instantiate(prefab, (transform.position + cam.transform.forward), transform.rotation);
			go.GetComponent<Rigidbody>().AddForce((transform.forward * force) * 100.0f);

			player.GetComponent<PlayerStats>().mana -= cost;
		}
	}
}