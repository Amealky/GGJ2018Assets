using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour {

	public void LoadLevel(string index){
		Application.LoadLevel(index);
	}

	public void QuitButton(){
		Debug.Log("Quit");
		Application.Quit();
	}
}