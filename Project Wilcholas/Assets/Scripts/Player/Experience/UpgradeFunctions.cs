using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeFunctions : MonoBehaviour {

	public void UpgradeStats (float percent) {
		FindObjectOfType<PlayerStats>().statLimit *= percent;
	}

	public void UpgradeRegenSpeed (float percent) {
		FindObjectOfType<PlayerStats>().regenSpeed *= percent;
	}
}
