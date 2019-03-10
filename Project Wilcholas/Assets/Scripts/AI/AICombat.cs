﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICombat : MonoBehaviour {

	public GameObject prefab;
    public AIMotor motor;
	[SerializeField] private float shootSpeed, force;
	private float ogShootSpeed;

	private void Awake () {
		ogShootSpeed = shootSpeed;
	}

	private void Update () {
		CombatController();
	}

	private void CombatController () {
		if(motor.agro)
        {
            ShootController();
        }
    }

    private void ShootController()
    {
        shootSpeed -= Time.deltaTime;

        if(shootSpeed < 0.0f)
        {
            Shoot();
            shootSpeed = ogShootSpeed;
        }
    }

    private void Shoot () {
		GameObject go = Instantiate(prefab, transform.position, transform.rotation, transform);
        go.GetComponent<Rigidbody>().AddForce((transform.forward * force) * 100.0f);
	}
}
