using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellFunctions : MonoBehaviour {
	
	[SerializeField] private GameObject[] gfx;
	private Transform player;

	private void Awake () {
		player = GameObject.FindWithTag("Player").transform;
	}

	public void Spell1 (Spell spell) {
		//GameObject go = Instantiate(gfx[0], (player.position + Camera.main.transform.forward), Quaternion.identity);
		//go.GetComponent<Rigidbody>().AddForce((player.forward * spell.value) * 100.0f);
	}
}
