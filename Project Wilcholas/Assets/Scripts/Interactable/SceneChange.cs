using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	[SerializeField] private int scene = 1;
	private Transform player;

	private void Awake () {
		player = GameObject.FindWithTag("Player").transform;
	}

	private void OnTriggerEnter (Collider other)
	{
		if(other.tag == "Player")
		{
			player.SetPositionAndRotation(new Vector3(0, 0, 0), Quaternion.identity);
			SceneManager.LoadScene(scene);
		}
	}
}
