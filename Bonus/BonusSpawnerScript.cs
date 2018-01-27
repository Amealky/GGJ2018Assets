using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawnerScript : MonoBehaviour {

	public 	GameObject 	bonusObject ;
	private int 		spawnPointsLength 	= 2;
 	public 	int[,] 		spawnPoints 		= new int[,] {
									 		{ 10, 20, 0 }, 
									 		{ 30, 50, 0 } 
									 	};
	private int 		lastSpawnTime = 0 ;								 	
	private int 		spawnCallDown = 2 ;
	// Use this for initialization
	void Start () { 
	}
	
	// Update is called once per frame
	void Update () {
		int curentTime = Mathf.RoundToInt(Time.time);	
	 	if(curentTime - lastSpawnTime > spawnCallDown){
	 		this.spawnobject();
	 	}
	}

	private void spawnobject(){
		lastSpawnTime = Mathf.RoundToInt( Time.time );
        this.getRandomSpawnPoint();
        // Vector3 relativePos = new Vector3(0, 0, 0);
        // Quaternion rotation = Quaternion.LookRotation(relativePos);
		Instantiate (bonusObject, this.getRandomSpawnPoint() ,  Quaternion.identity );
	}

	private Vector3 getRandomSpawnPoint(){
		int spawnPointPosition = Random.Range(0, spawnPointsLength);
		Vector3 spawnPoint = new Vector3( spawnPoints[spawnPointPosition, 0 ] , spawnPoints[spawnPointPosition, 1 ] ,  spawnPoints[spawnPointPosition, 2]  );
		// Debug.Log("spawnPoint " + spawnPoint );
		return spawnPoint;
	}
}
