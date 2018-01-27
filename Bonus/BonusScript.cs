using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScript : MonoBehaviour {


	public BonusThrowedScript bonusThrowed;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {



	}

    void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {

			
			other.gameObject.GetComponent<PersonnageModel> ().power = bonusThrowed;
			Destroy (gameObject);

		} 
    }
}
