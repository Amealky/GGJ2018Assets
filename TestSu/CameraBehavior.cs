using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Camera cam = this.GetComponent<Camera>();
		float targetaspect = 16.0f/9.0f;
		float windowaspect = (float)Screen.width/(float)Screen.height;
		float scaleHeight = windowaspect / targetaspect;

		if (scaleHeight < 1.0f) {
			Rect rect = cam.rect;
			rect.width = scaleHeight;
			rect.x = 0;
			rect.y = (1.0f - scaleHeight) / 2.0f;
			cam.rect = rect;
		} 
		else {
			float scalewidth = 1.0f / scaleHeight;
			Rect rect = cam.rect;
			rect.width = scalewidth;
			rect.height = 1.0f;
			rect.x = (1.0f - scalewidth) / 2.0f;
			rect.y = 0;
			cam.rect = rect;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
