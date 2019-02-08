using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

	[Header("Sprites")]
	public Color color;

	private void Update () {
		SpriteBrightness();
	}

	private void SpriteBrightness () {
		foreach (var renderer in FindObjectsOfType<SpriteRenderer>())
		{
			renderer.color = color;
		}
	}
}
