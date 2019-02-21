using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSouls : MonoBehaviour {

	[HideInInspector] public bool soulReady;
	public GameObject spellsPanel;
	private GameObject soulIndicator;

	private void Start () {
		soulIndicator = GameObject.FindWithTag("SoulIndicator");
	}

	private void Update () {
		Indicator();
	}
	
	private void Indicator () {
		if(soulReady)
		{
			soulIndicator.SetActive(true);
			return;
		}

		soulIndicator.SetActive(false);
	}
}
