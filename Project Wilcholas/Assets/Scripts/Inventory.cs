using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	[SerializeField] private Transform inventory;
	public List<GameObject> slots;

	private void Start () {
		SlotSetup();
	}

	private void SlotSetup () {
		for(int i = 0; i < inventory.childCount; i++)
		{
			slots.Add(inventory.GetChild(i).gameObject);
		}
	}
}
