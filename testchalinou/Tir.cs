using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour {

	public int direction;
	public float speed;
	public float bulletDamage;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float xTranslation = Time.deltaTime * speed;

		transform.Translate (new Vector3 (xTranslation * direction, 0, 0));

		
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Player") {
			Destroy (gameObject);
		}
	}

}
