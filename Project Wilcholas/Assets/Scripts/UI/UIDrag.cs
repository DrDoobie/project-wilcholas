using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDrag : MonoBehaviour {

	private float xOffset, yOffset;

	public void BeginDrag () {
		xOffset = transform.position.x - Input.mousePosition.x;
		yOffset = transform.position.y - Input.mousePosition.y;
	}

	public void OnDrag () {
		transform.position = new Vector3((xOffset + Input.mousePosition.x), (yOffset + Input.mousePosition.y));
	}
}
