using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCarryOver : MonoBehaviour {

	private void Awake () {
		DontDestroyOnLoad(gameObject);
	}
}
