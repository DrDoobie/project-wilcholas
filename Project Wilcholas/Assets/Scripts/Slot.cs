using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

	public bool isOccupied;

	private void Update () {
		SlotController();
	}

	private void SlotController () {
		if(transform.childCount > 0)
		{
			isOccupied = true;

		} else {
			isOccupied = false;
		}
	}
}
