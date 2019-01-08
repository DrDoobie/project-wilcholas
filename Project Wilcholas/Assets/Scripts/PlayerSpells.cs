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
		var msw = Input.GetAxis("Mouse ScrollWheel");

		if(msw > 0.0f)
		{
			currentSpell++;

		} else if(msw < 0.0f) {
			currentSpell--;
		}
		
		spellEquipped = spells[currentSpell];
			Debug.Log(currentSpell);
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
