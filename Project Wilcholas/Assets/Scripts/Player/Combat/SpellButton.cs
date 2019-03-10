using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellButton : MonoBehaviour {

	private PlayerSouls playerSouls;

	private void Start () {
		playerSouls = FindObjectOfType<PlayerSouls>();
	}

    public void Learn()
    {
		if(!playerSouls.soulReady)
		{
			Debug.Log("Soul Not Ready");
			return;
		}

        GetComponent<Button>().interactable = false;
    }
}
