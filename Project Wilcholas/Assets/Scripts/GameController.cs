﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	[HideInInspector] public bool isPaused;

	private void Update () {
		PauseController();
	}
	private void PauseController () {
		if(Input.GetButtonDown("Pause"))
		{
			isPaused = !isPaused;
		}

		if(isPaused)
		{
			//Freeze time
			Time.timeScale = 0.0f;

			//Adjust cursor
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;

		} else {
			Time.timeScale = 1.0f;

			//Adjust cursor
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
	}
}