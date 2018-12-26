using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	[SerializeField] private GameObject sprite;
	private Inventory inventory;

	private void Start () {
		Setup();
	}

	private void Setup () {
		inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
	}

	private void Add () {
		inventory.AddItem(sprite);
			Destroy(this.gameObject);
	}

	private void OnTriggerEnter (Collider other) {
		if(other.tag == "Player")
		{
			Add();
		}
	}
}
