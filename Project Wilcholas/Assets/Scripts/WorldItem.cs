using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : MonoBehaviour {

	[SerializeField] private int itemID;
	private Inventory inventory;
	private ItemDatabase itemDB;

	private void Start () {
		Setup();
	}

	private void Setup () {
		inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
		itemDB = GameObject.FindWithTag("GameController").GetComponent<ItemDatabase>();
	}

	private void Add () {
		inventory.AddItem();
			Destroy(this.gameObject);
	}

	private void OnTriggerEnter (Collider other) {
		if(other.tag == "Player")
		{
			Add();
		}
	}
}
