using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	[HideInInspector] public bool isPaused;
	[HideInInspector] public int maxAI, currentAI;

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
            FreeCursor();
			return;
        }

		LockCursor();
    }

    private static void LockCursor()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void FreeCursor () {
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}

