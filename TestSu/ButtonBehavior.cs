using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour {

	private GameObject[] pauseObjects;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		hidePaused();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			
			if (Time.timeScale == 1) {
				Time.timeScale = 0;
				Debug.Log("Temps pausé");
				showPaused();


			} else if (Time.timeScale == 0) {
				Time.timeScale = 1;
				Debug.Log("Temps repris");
				hidePaused();
			}
		}
	}

	public void reprendre(){
		if (Time.timeScale == 1) {
			Time.timeScale = 0;
			showPaused();
		} else if (Time.timeScale == 0) {
			Time.timeScale = 1;
			hidePaused();
		}
	}

	public void showPaused(){
		foreach (GameObject g in pauseObjects) {
			Debug.Log ("Show");
			g.SetActive(true);
		}
	}

	public void hidePaused(){
		foreach (GameObject g in pauseObjects) {
			Debug.Log ("Hide");
			g.SetActive(false);
		}
	}

	public void LoadLevel(string index){
		SceneManager.LoadScene(index);
	}

	public void QuitButton(){
		Debug.Log("Quit");
		Application.Quit();
	}
}