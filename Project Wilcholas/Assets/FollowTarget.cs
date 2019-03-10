using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour {

	public bool followPlayer;
	public Transform target;
	public float speed;

	private void Update () {
		if(followPlayer)
		{
			target = GameObject.FindGameObjectWithTag("Player").transform;
		}
		
		transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
	}
}
