using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour {

	[SerializeField] private int direction;
	[SerializeField] private GameObject[] tiles, spawns;

	private void Awake () {
		SpawnTiles();
	}

	private void SpawnTiles () {
		//Clean here later
		int spawn = 0;
		int tile = 0;

		foreach(var GameObject in spawns)
		{
			if(direction == 0)
			{
				Instantiate(tiles[tile], spawns[spawn].transform.position, spawns[spawn].transform.rotation);
					tile++;
			}

			spawn++;
		}		
	}
}
