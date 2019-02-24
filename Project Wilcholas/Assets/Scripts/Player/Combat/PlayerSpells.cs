using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpells : MonoBehaviour {

    private PlayerSouls playerSouls;
	[SerializeField] private int currentSpell = 0;

	private void Start () {
        playerSouls = FindObjectOfType<PlayerSouls>();
		SelectSpell();
	}

	private void Update ()
    {
        SpelLController();
    }

	public void LearnSpell (GameObject obj) {
	    if(playerSouls.soulReady)
        {
            Instantiate(obj, transform.position, transform.rotation, transform);
            playerSouls.soulReady = false;
        }
	}

    private void SpelLController()
    {
        int previousSpell = currentSpell;
        var msw = Input.GetAxis("Mouse ScrollWheel");

        if(msw > 0.0f)
        {
            if(currentSpell >= (transform.childCount - 1))
                currentSpell = 0;
            else
                currentSpell++;
        }

        if(msw < 0.0f)
        {
            if(currentSpell <= 0)
                currentSpell = (transform.childCount - 1);
            else
                currentSpell--;
        }

        if(previousSpell != currentSpell)
            SelectSpell();
    }

    private void SelectSpell () {
		int i = 0;

		foreach(Transform tran in transform)
		{
			if(i == currentSpell)
				tran.gameObject.SetActive(true);
			else
				tran.gameObject.SetActive(false);

			i++;
		}
	}
}
