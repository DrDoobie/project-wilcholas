using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpells : MonoBehaviour {

	public Component spellEquipped;
	public List<Component> spells;
	public int currentSpell;

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
		Debug.Log("woosh");
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
