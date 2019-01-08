using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpells : MonoBehaviour {

	public Spell spellEquipped;
	public List<Spell> spells;
	private int currentSpell;

	private void Update () {
		SpellController();
			CastController();
	}

	private void SpellController () {
		if(spells.Count > 0)
		{
			//Sort through spell list with mosue scroll wheel
			var msw = Input.GetAxis("Mouse ScrollWheel");

			//Positive scroll wheel movement
			if(msw > 0.0f)
			{
				currentSpell++;

			//Negative movement
			} else if(msw < 0.0f) {
				currentSpell--;
			}

			SpellClamp();
			spellEquipped = spells[currentSpell];
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

	private void CastController () {
		if(Input.GetButtonDown("Fire1"))
		{
			//Cast spell only if you have enough mana
			if(GetComponent<PlayerStats>().mana > spellEquipped.cost)
			{
				CastSpell();
			}
		}
	}

	private void CastSpell () {
		if(spellEquipped != null)
		{
			//Spawn projectile and add force
			GameObject go = Instantiate(spellEquipped.gfx, (transform.position + Camera.main.transform.forward), (transform.rotation));
				go.GetComponent<Rigidbody>().AddForce((transform.forward * spellEquipped.force) * 100.0f);

			//Take mana
			GetComponent<PlayerStats>().mana -= spellEquipped.cost;
		}
	}
}
