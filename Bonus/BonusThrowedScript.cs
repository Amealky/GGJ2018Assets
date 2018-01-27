using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusThrowedScript : MonoBehaviour {

	public int speed = 10;
	public bool isMalus = false;
	public bool isBonus = true;
	public int direction = 1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
	    bool onScreen = screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
		if(!onScreen){
			Destroy(gameObject);
		}
		float xTranslation = Time.deltaTime * speed;

		transform.Translate (new Vector3 (xTranslation * direction, 0, 0));
	}
}
