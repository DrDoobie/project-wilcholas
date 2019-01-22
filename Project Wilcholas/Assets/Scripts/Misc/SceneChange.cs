﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	[SerializeField] private int scene = 1;

	private void OnTriggerEnter (Collider other)
	{
		if(other.tag == "Player")
		{
			SceneManager.LoadScene(scene);
		}
	}
}