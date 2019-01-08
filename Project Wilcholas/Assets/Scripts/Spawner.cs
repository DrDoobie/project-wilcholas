using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField] private bool aiSpawner;
	[SerializeField] private GameObject obj;
    private GameController gameController;
    [SerializeField] private float spawnTimer;

    private void Start () {
        StartCoroutine(SpawnTimer());
            gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    public void Spawn () {
        Instantiate(obj, transform.position, transform.rotation);
    }

    private IEnumerator SpawnTimer () {
        while(true)
        {
            yield return new WaitForSeconds(spawnTimer);

            //If ai spawner then only spawn if ai cap is not reached
            if(aiSpawner)
            {
                if(gameController.currentAI < gameController.maxAI)
                {
                    Spawn();
                }

            } else {
                Spawn();
            }
        }
    }
}
