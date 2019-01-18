using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExperience : MonoBehaviour {

	[SerializeField] private float xpLevel = 1.0f, requiredXp = 10.0f, currentXp = 0.0f, multiplier = 1.25f;
	private Slider xpBar;
	private Text levelIndicator;
	private PlayerStats playerStats;

	private void Start () {
		SetValues();
	}

	private void SetValues () {
		xpBar = GameObject.FindWithTag("ExperienceBar").GetComponent<Slider>();
			levelIndicator = GameObject.FindWithTag("LevelIndicator").GetComponent<Text>();
				playerStats = GetComponent<PlayerStats>();
	}

	private void Update () {
		LevelController();
			UIController();
	}

	private void LevelController () {
		if(currentXp == requiredXp)
		{
			LevelUp();

		} else if (currentXp > requiredXp) {
			//Add left over xp when leveling up
			float val1 = (currentXp - requiredXp);
				LevelUp();
					currentXp += val1;
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
		//Increment, reset, increase xp
		xpLevel ++;
			currentXp = 0.0f;
				requiredXp *= multiplier;

		//Increase stats
		playerStats.statLimit *= multiplier;

		//Reset stats
		playerStats.health = playerStats.statLimit;
			playerStats.stamina = playerStats.statLimit;
				playerStats.mana = playerStats.statLimit;
	}

	public void AddXp (float value) {
		currentXp += value;
	}
}
