using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour {

	//1- Requires +x door, 2- Requires -z door, 3- Requires -x door, 4- Requires +z
	[SerializeField] private int openDir;
	private bool spawned = false;
	private TileTemplates templates;

	private void Start () {
		templates = GameObject.FindWithTag("TileTemplates").GetComponent<TileTemplates>();
			Invoke("SpawnTiles", 0.1f);
	}

	private void SpawnTiles () {
		if(!spawned)
		{
			int val = 0;

			if(openDir == 1)
			{
				val = Random.Range(0, templates.posX.Length);
					Instantiate(templates.posX[val], transform.position, Quaternion.identity);

			} else if(openDir == 2) {
				val = Random.Range(0, templates.negZ.Length);
					Instantiate(templates.negZ[val], transform.position, Quaternion.identity);

			} else if(openDir == 3) {
				val = Random.Range(0, templates.negX.Length);
					Instantiate(templates.negX[val], transform.position, Quaternion.identity);

			} else if(openDir == 4) {
				val = Random.Range(0, templates.posZ.Length);
					Instantiate(templates.posZ[val], transform.position, Quaternion.identity);
			}

			spawned = true;
		}
	}

	private void OnTriggerEnter (Collider other)
	{
		if((other.tag == "TileSpawn") && (other.GetComponent<TileSpawner>().spawned))
		{
			Destroy(gameObject);
		}
	}
}
