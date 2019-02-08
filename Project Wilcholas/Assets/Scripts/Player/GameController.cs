using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	[HideInInspector] public bool isPaused;
	[HideInInspector] public int maxAI, currentAI;
    public Color color;

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

    private void SpriteBrightness () {
		foreach (var renderer in FindObjectsOfType<SpriteRenderer>())
		{
			renderer.color = color;
		}
	}

    private static void LockCursor () {
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

