using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour {

	public int direction;
	public float speed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		float xTranslation = Time.deltaTime * speed;

		transform.Translate (new Vector3 (xTranslation * direction, 0, 0));
		
	}




}
