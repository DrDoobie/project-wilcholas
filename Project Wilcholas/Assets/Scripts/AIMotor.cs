using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMotor : MonoBehaviour {

	private Transform target;
	private NavMeshAgent agent;

	private void Awake () {
		agent = this.gameObject.GetComponent<NavMeshAgent>();
			target = GameObject.FindWithTag("Player").transform;
				GameObject.FindWithTag("GameController").GetComponent<GameController>().currentAI++;
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
