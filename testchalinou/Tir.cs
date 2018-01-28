using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour {

	public Vector3 directionXY;
	public float speed;
	public float bulletDamage;
	public int 	 bounsCount;
	public int 	 maxBouns;

	void Awake(){

	}
	// Use this for initialization
	void Start () {
		speed = 0.05f;
		bounsCount 	= 0 ;
		maxBouns 	= 2 ;
		//directionXY = new Vector3(direction, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		float xTranslation = Time.deltaTime * speed;
		Vector3 newVector = new Vector3 (
			(Time.deltaTime * speed)+(directionXY.x*speed), 
			(Time.deltaTime * speed)+(directionXY.y*speed), 
			0);
		transform.Translate ( newVector);
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
		if(collider.gameObject.name == "Mur Gauche" || collider.gameObject.name == "Mur Droite"){
			directionXY = new Vector3(-directionXY.x , directionXY.y, directionXY.z);
			bounsCount++;
		}else if(collider.gameObject.name == "Mur Haut" || collider.gameObject.name == "Mur Bas"){
			directionXY = new Vector3(directionXY.x , -directionXY.y, directionXY.z);
			bounsCount++;
		}
		if(bounsCount >= maxBouns){
			Destroy (gameObject);
		}
	}

}
