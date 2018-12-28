using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMotor : MonoBehaviour {

	[SerializeField] private Transform target;
	private NavMeshAgent agent;

	private void Start () {
		agent = this.gameObject.GetComponent<NavMeshAgent>();
	}

	private void Update () {
		MovementController();
	}

	private void MovementController () {
		//If target exists, pursue 
		if(target != null)
		{
			agent.SetDestination(target.position);
		}
	}
}
