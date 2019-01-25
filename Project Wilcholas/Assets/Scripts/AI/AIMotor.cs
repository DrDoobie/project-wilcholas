using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMotor : MonoBehaviour {

	[HideInInspector] public bool agro = false;
	[SerializeField] private float wanderTime = 3.0f, wanderRadius = 20.0f;
	private NavMeshAgent agent;
	private GameController gc;

	private void Awake () {
		agent = gameObject.GetComponent<NavMeshAgent>();
		gc = GameObject.FindWithTag("GameController").GetComponent<GameController>();
		gc.currentAI++;

		StartCoroutine(Wander());
	}

	private void Update () {
		if(agro)
		{
			agent.SetDestination(GameObject.FindWithTag("Player").transform.position);
		}
	}

	private IEnumerator Wander () {
		while(!agro)
		{
			Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
			agent.SetDestination(newPos);

			yield return new WaitForSeconds(wanderTime);
		}
	}

	public static Vector3 RandomNavSphere (Vector3 origin, float radius, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * radius;
		randDirection += origin;
		NavMeshHit navHit;
		NavMesh.SamplePosition (randDirection, out navHit, radius, layermask);
		return navHit.position;
    }
}
