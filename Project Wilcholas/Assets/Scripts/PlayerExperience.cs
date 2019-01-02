using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExperience : MonoBehaviour {

	[SerializeField] private float xpLevel = 1.0f, requiredXp = 10.0f, currentXp = 0.0f;
	private Slider xpBar;
	private Text levelIndicator;

	private void Start () {
		xpBar = GameObject.FindWithTag("ExperienceBar").GetComponent<Slider>();
			levelIndicator = GameObject.FindWithTag("LevelIndicator").GetComponent<Text>();
	}

	private void Update () {
		LevelController();
			UIController();
	}

	private void LevelController () {
		if(currentXp >= requiredXp)
		{
			LevelUp();
		}
	}

	private void UIController () {
		//Level indicator
		levelIndicator.text = xpLevel.ToString();

		//Experience bar
		xpBar.maxValue = requiredXp;
			xpBar.value = currentXp;
	}

	private void LevelUp () {
		//Increment level
		xpLevel ++;
			//Reset xp
			currentXp = 0.0f;
				//Increase required xp by percentage
				requiredXp *= 1.25f;
	}

	public void AddXp (float value) {
		currentXp += value;
	}
}
