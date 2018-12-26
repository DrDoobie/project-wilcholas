using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	private Inventory inventory;

	private void Start () {
		Setup();
	}

	private void Setup () {
		inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
	}

	private void OnTriggerEnter (Collider other) {
		if(other.tag == "Player")
		{
			for(int i = 0; i < inventory.slots.Count; i++)
			{
				if(!inventory.slots[i].GetComponent<Slot>().isOccupied)
				{
					//Add item to inventory
					Destroy(this.gameObject);

					break;
				}
			}
		}
	}
}
