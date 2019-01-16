using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMotor : MonoBehaviour {

	public bool wander, agro;
	[SerializeField] private float wanderTimer = 6.0f, wanderRadius = 20.0f;
	private NavMeshAgent agent;
	private float timer;

	private void Awake () {
		agent = this.gameObject.GetComponent<NavMeshAgent>();
				GameObject.FindWithTag("GameController").GetComponent<GameController>().currentAI++;
					timer = wanderTimer;
	}

	private void Update () {
		if(wander)
		{
			WanderController();

		} else if(agro) {
			Agro();
		}
	}

	private void WanderController () {
		agro = false;
			timer += Time.deltaTime;
 
        if (timer >= wanderTimer) {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
				agent.SetDestination(newPos);
					timer = 0;
        }
	}

	public void Agro () {
		wander = false;
			agro = true;
				agent.SetDestination(GameObject.FindWithTag("Player").transform.position);
	}

	public static Vector3 RandomNavSphere(Vector3 origin, float radius, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * radius;
			randDirection += origin;
				NavMeshHit navHit;
					NavMesh.SamplePosition (randDirection, out navHit, radius, layermask);
						return navHit.position;
    }
}
