using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUpgrade : MonoBehaviour {

	[SerializeField] private bool isLocked;
	private bool isPurchased = false;
	public GameObject lockImg, nextLevel;
	private int skillPoints;

	private void Update ()
    {
        Controller();
    }

    private void Controller() {
		skillPoints = FindObjectOfType<PlayerExperience>().skillPoints;

        if(isLocked)
        {
            return;
        }

		if(isPurchased)
		{
			GetComponent<Button>().interactable = false;
			return;
		}

        lockImg.SetActive(false);
        GetComponent<Button>().interactable = true;
    }

	public void Purchase () {
		if(skillPoints <= 0)
		{
			return;
		}

		FindObjectOfType<PlayerExperience>().skillPoints--;
		isPurchased = true;

		if(nextLevel != null)
			nextLevel.GetComponent<SkillUpgrade>().isLocked = false;
	}
}
