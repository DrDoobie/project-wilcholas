using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExperience : MonoBehaviour {

	[SerializeField] private Slider xpBar;
	[SerializeField] private Text levelIndicator;
	private PlayerStats playerStats;
	[SerializeField] private float multiplier = 1.25f;
	[HideInInspector] public float xpLevel = 1.0f, requiredXp = 10.0f, currentXp = 0.0f;
	[Header("Skill Tree")] public GameObject window;
	public Text skillPointsText;
	public int skillPoints;
	private bool skillTreeOpen;


	private void Awake () {
		playerStats = GetComponent<PlayerStats>();
	}

	private void Update () {
		if(Input.GetButtonDown("Skill Tree"))
		{
			skillTreeOpen = !skillTreeOpen;
		}

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
		levelIndicator.text = xpLevel.ToString();
		xpBar.maxValue = requiredXp;
		xpBar.value = currentXp;

		if(skillTreeOpen)
		{
			window.SetActive(true);
			skillPointsText.text = "Skill Points: " + skillPoints;
			return;
		}

		window.SetActive(false);
	}

	private void LevelUp ()
    {
        xpLevel++;
		skillPoints++;
        currentXp = 0.0f;
        requiredXp *= multiplier;
        FillStats();
    }

    private void FillStats () {
        playerStats.health = playerStats.statLimit;
        playerStats.stamina = playerStats.statLimit;
        playerStats.mana = playerStats.statLimit;
    }

    public void AddXp (float value) {
		currentXp += value;
	}
}
