using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICombat : MonoBehaviour {

	public GameObject prefab;
	[SerializeField] private float shootSpeed;
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
		Instantiate(prefab, transform.position, transform.rotation, transform);
	}
}
