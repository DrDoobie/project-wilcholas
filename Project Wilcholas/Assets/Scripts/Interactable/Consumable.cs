using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour {

	[SerializeField] private float value;
	[Header("Type")]
	[SerializeField] private bool health;
	[SerializeField] private bool stamina;
	[SerializeField] private bool mana;
	[SerializeField] private bool xp;
	[SerializeField] private bool coins;
	[SerializeField] private bool hallucinogen;
	private GameObject player, gc;

	private void Awake () {
		player = GameObject.FindWithTag("Player");
		gc = GameObject.FindWithTag("GameController");
	}

	private void OnTriggerEnter (Collider other) {
		if(other.tag == "Player")
		{
			Consume();
		}
	}

	private void Consume () {
		//Dirt code here, must clean later
		if(health)
		{
			if(player.GetComponent<PlayerStats>().health < player.GetComponent<PlayerStats>().statLimit)
			{
				player.GetComponent<PlayerStats>().health += value;
					Destroy(this.gameObject);
			}
		}
			if(stamina) 
			{
				if(player.GetComponent<PlayerStats>().stamina < player.GetComponent<PlayerStats>().statLimit)
				{
					player.GetComponent<PlayerStats>().stamina += value;
						Destroy(this.gameObject);
				}
			}
				if(mana) 
				{
					if(player.GetComponent<PlayerStats>().mana < player.GetComponent<PlayerStats>().statLimit)
					{
						player.GetComponent<PlayerStats>().mana += value;
							Destroy(this.gameObject);
					}	
				}
					if(xp) 
					{
						player.GetComponent<PlayerExperience>().AddXp(value);
							Destroy(this.gameObject);
					}
						if(coins)
						{
							player.GetComponent<PlayerStats>().coins += (int)value;
								Destroy(this.gameObject);
						}
							if(hallucinogen)
							{
								gc.GetComponent<ProfileChanger>().Trip();
							}
	}
}
