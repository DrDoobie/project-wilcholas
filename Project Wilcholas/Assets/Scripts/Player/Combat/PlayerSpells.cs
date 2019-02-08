using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpells : MonoBehaviour {

	public Spell spellEquipped;
	public List<Spell> spells;
	private PlayerStats player;
	private int currentSpell;

	private void Awake () {
		player = GetComponent<PlayerStats>();
	}

	private void Update () {
		SpellController();

		if(Input.GetButtonDown("Fire1") && (spellEquipped != null))
		{
			CastSpell();
		}
	}

	private void SpellController () {
		if(spells.Count > 0)
        {
            ScrollController();
            SpellClamp();
            spellEquipped = spells[currentSpell];
        }
    }

	private void CastSpell () {
		if((player.mana > spellEquipped.cost) && (!FindObjectOfType<GameController>().isPaused))
		{
			spellEquipped.function.Invoke();
			player.mana -= spellEquipped.cost;
		}
	}

	private void ScrollController () {
        var msw = Input.GetAxis("Mouse ScrollWheel");

        if(msw > 0.0f)
        {
            currentSpell++;

        } else if(msw < 0.0f) {
            currentSpell--;
        }
    }

    private void SpellClamp () {
		if(currentSpell < 0)
		{	
			currentSpell = (spells.Count - 1);

		} else if(currentSpell >= spells.Count) {
			currentSpell = 0;
		}
	}
}
