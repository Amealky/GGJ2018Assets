using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeUi : MonoBehaviour {
private Vector3 initiatePosition;
private float 	startShaking;
private float 	ShakeForce;
private float 	ShakeTime;
private bool 	ShakeItUp;
private float 	MaxShakesForce;
	// Use this for initialization
	void Start () {
		initiatePosition = GetComponent<RectTransform>().position;
		ShakeItUp = false;
		startShaking = 0;
		ShakeForce = 0 ;
		ShakeTime = 0 ;
		MaxShakesForce = 30;
	}
	
	// Update is called once per frame
	void Update () {
		if (ShakeItUp) {
			if(Time.time-startShaking>ShakeTime){
				ShakeItUp = false;
				GetComponent<RectTransform>().position = initiatePosition;
			}else{
				var randomPose = new Vector3(
					initiatePosition.x+Random.Range(-ShakeForce, ShakeForce), 
					initiatePosition.y+Random.Range(-ShakeForce, ShakeForce), 
					initiatePosition.z
				); //Random.Range(1, 3)
				GetComponent<RectTransform>().position = randomPose;
			}
		}
	}

	public void ShakeIt(float force, float howlong){
		this.ShakeItUp = true;
		this.startShaking = Time.time;
		this.ShakeForce = force/2;
		this.ShakeForce = (ShakeForce > MaxShakesForce) ? MaxShakesForce : ShakeForce;
		this.ShakeTime = howlong;
	}
}
