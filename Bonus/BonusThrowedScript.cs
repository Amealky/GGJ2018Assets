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
		float xTranslation = Time.deltaTime * speed;

		transform.Translate (new Vector3 (xTranslation * direction, 0, 0));
	}
}
