using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpells : MonoBehaviour {

	public GameObject spellEquipped;
	public List<GameObject> spells;
	public int currentSpell;

	private void Update () {
		SpellController();
	}

	public void LearnSpell (GameObject spell) {
		Instantiate(spell, transform.position, transform.rotation, transform);
		spells.Add(spell);
	}

	private void SpellController ()
    {
        if(spells.Count > 0)
        {
            ScrollController();
            ScrollClamp();

            spellEquipped = spells[currentSpell];
        }

		int spellNum = 0;
    }

    private void ScrollController () {
		ScrollClamp();
        var msw = Input.GetAxis("Mouse ScrollWheel");

        if(msw > 0.0f)
        {
            currentSpell++;

        } else if(msw < 0.0f) {
            currentSpell--;
        }
    }

    private void ScrollClamp () {
		if(currentSpell < 0)
		{	
			currentSpell = (spells.Count - 1);

		} else if(currentSpell == spells.Count) {
			currentSpell = 0;
		}
	}
}
