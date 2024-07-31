using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
	//Serializefield serve a visualizzare le variabili private nell'inspector

	[SerializeField] private GameObject[] enemy;
	[SerializeField] private GameObject[] enemyList;
	[SerializeField] private int enemyLength;
	public Transform spawnPoint;
	[SerializeField] private float yFlying;
	[SerializeField] private float timeToSpawn;
	private float tEnemySpawn=0;
	private int enemyCounter=0;
	void Awake()
	{
		//Inizializziamo l'array dei nostri nemici con lunghezza pari a "enemylength"

	}

	void Start()
	{
		
		enemyList = new GameObject[enemyLength];

		//Riempiamo l'array dei nostri nemici con delle copie del prefab "enemy" e disattiviamo gli oggetti una volta instanziati
		for (int i = 0; i < enemyLength; i++) {
			enemyList [i] = GameObject.Instantiate (enemy[Random.Range(0,2)], spawnPoint.position, spawnPoint.rotation);
			enemyList [i].SetActive (false);
		}
	}

	void Update()
	{
		tEnemySpawn += Time.deltaTime;
		if (tEnemySpawn > timeToSpawn)
			SpawnEnemy ();	
	}

	void SpawnEnemy()
	{
		tEnemySpawn = 0;

		for (int i = enemyCounter; i < enemyLength; i++) {
			if (!enemyList [i].activeInHierarchy) {
				if (enemyList [i].tag == "Helicopter")
					enemyList [i].GetComponent<Enemy> ().Spawn (spawnPoint, yFlying);
				else
					enemyList [i].GetComponent<Enemy> ().Spawn (spawnPoint);

				enemyCounter = i+1;
				break;
			}
			if (enemyCounter == enemyLength)
				enemyCounter = 0;
		}
	}
}
