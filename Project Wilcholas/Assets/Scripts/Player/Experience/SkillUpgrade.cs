using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUpgrade : MonoBehaviour {

	[SerializeField] private bool isLocked;
	private bool isPurchased = false;
	public GameObject lockImg, nextSkill;
	public Skill skill;
	public Text text;
	private int skillPoints;

	private void Update ()
    {
		text.text = skill.skillDescription;
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

		skill.function.Invoke();
		FindObjectOfType<PlayerExperience>().skillPoints--;
		isPurchased = true;

		if(nextSkill != null)
			nextSkill.GetComponent<SkillUpgrade>().isLocked = false;
	}
}
