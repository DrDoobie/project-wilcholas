using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICombat : MonoBehaviour {

	public GameObject prefab;
	[SerializeField] private float force, shootSpeed;
	private float ogShootSpeed;

	private void Awake () {
		ogShootSpeed = shootSpeed;
	}

	private void Update () {
		CombatController();
	}

	private void CombatController () {
		AIMotor motor = GetComponent<AIMotor>();

		if(motor.agro)
		{	
			shootSpeed -= Time.deltaTime;

			if(shootSpeed < 0.0f)
			{
				Shoot();
				shootSpeed = ogShootSpeed;
			}
		}
	}

	private void Shoot () {
		GameObject go = Instantiate(prefab, transform.position, transform.rotation, transform);
		go.GetComponent<Rigidbody>().AddForce((transform.forward * force) * 100.0f);
	}
}
