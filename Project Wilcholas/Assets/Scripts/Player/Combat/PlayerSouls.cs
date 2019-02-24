using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSouls : MonoBehaviour {

	[HideInInspector] public bool soulReady;
	public GameObject spellsPanel;
	private GameObject soulIndicator;
	private bool open = false;

	private void Start () {
		soulIndicator = GameObject.FindWithTag("SoulIndicator");
	}

	private void Update () {
		WindowController();
		Indicator();
	}

	private void WindowController () {
		if(Input.GetButtonDown("Spells"))
		{
			open = !open;
		}

		if(open)
		{
			spellsPanel.SetActive(true);
			return;
		}

		spellsPanel.SetActive(false);
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
