using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	[SerializeField] private int scene = 1;

	private void ChangeScene () {
		Vector3 zero = new Vector3(0, 0, 0);
		GameObject.FindGameObjectWithTag("Player").transform.SetPositionAndRotation(zero, Quaternion.identity);
		SceneManager.LoadScene(scene);
	}

	private void OnTriggerEnter (Collider other)
	{
		if(other.tag == "Player")
		{
			ChangeScene();
		}
	}
}
