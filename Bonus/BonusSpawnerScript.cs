using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawnerScript : MonoBehaviour {

	public 	GameObject 	bonusObject ;
	public 	GameObject 	mapFlor ;
	private int 		lastSpawnTime 	= 0 ;								 	
	private int 		spawnCallDown 	= 1 ;
	private int 		mapTop 			= 0 ;
	private int 		mapBottom 		= 0;
	private int 		mapLeft 		= 0 ;
	private int 		mapRight 		= 0;
	private int 		mapXMiddle 		= 0;

	// Use this for initialization
	void Start () {
		mapFlor = GameObject.Find("MapFlor");
		BoxCollider2D m_Collider = mapFlor.GetComponent<BoxCollider2D>();
		mapTop 		= Mathf.RoundToInt( mapFlor.transform.position.y + ( m_Collider.size.y / 2 ));
		mapBottom 	= Mathf.RoundToInt( mapFlor.transform.position.y - ( m_Collider.size.y / 2 ));
		mapLeft 	= Mathf.RoundToInt( mapFlor.transform.position.x - ( m_Collider.size.x / 2 ));
		mapRight 	= Mathf.RoundToInt( mapFlor.transform.position.x + ( m_Collider.size.x / 2 ));
		mapXMiddle 	= Mathf.RoundToInt( mapFlor.transform.position.x );
	}
	
	// Update is called once per frame
	void Update () {
		int curentTime = Mathf.RoundToInt(Time.time);
	 	if(curentTime - lastSpawnTime > spawnCallDown){
	 		this.spawnobjectS();
	 	}
	}

	private void spawnobjectS(){
		lastSpawnTime = Mathf.RoundToInt( Time.time );
		Instantiate (bonusObject, this.getRandomSpawnPoint(true) ,  Quaternion.identity );
	}

	private Vector3 getRandomSpawnPoint(bool leftTeam){
		int spawnPointX = leftTeam ?  Random.Range(mapLeft, mapXMiddle) : Random.Range(mapXMiddle, mapRight) ;
		int spawnPointY = Random.Range(mapBottom, mapTop);
		Vector3 spawnPoint = new Vector3( spawnPointX , spawnPointY ,  0  );
		return spawnPoint;
	}
}
