using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMotor : MonoBehaviour {

	public Transform target;
	private NavMeshAgent agent;

	private void Start () {
		SetValues();
	}

	private void SetValues () {
		agent = this.gameObject.GetComponent<NavMeshAgent>();
	}
}
