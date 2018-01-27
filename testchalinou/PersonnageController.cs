using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageController : MonoBehaviour {

	private PersonnageModel model;
	

	//Zak
    void OnTriggerEnter2D(Collider2D other) {
    	Debug.Log("eee");
    	Debug.Log("colision enter 2d");
    	if (other.gameObject.tag == "Bonus"){
    		pickUpBonus();
	    }else if(other.gameObject.tag == "Vide"){
	    	tombeDansLeVide();
    	}
    }

    void tombeDansLeVide(){
    	Destroy(gameObject);
    }

	void pickUpBonus(){
    	model.hasBonus = true;
	}

	//Zak
	
	void Awake(){
		model = this.gameObject.GetComponent<PersonnageModel> ();
	}

	// Use this for initialization

	void Start () {
		model.sprite = this.gameObject.GetComponent<SpriteRenderer> ();
		model.shootPoint = transform.Find ("ShootPoint");
		// model.power = this.gameObject.GetComponent<Power> ();

		model.power = this.gameObject.GetComponent<Power> ();
		model.tir = this.gameObject.GetComponent<Tir> ();
		//Zak
		//Zak
	}
	
	// Update is called once per frame
	void Update () {
		model.hasMalus = true;
		float translation =  Time.deltaTime * model.moveSpeed ;
		// float translation = model.hasBonus ?  Time.deltaTime * ( model.moveSpeed + model.bonusMooveSpeed ) : ( Time.deltaTime * model.moveSpeed ) ;
		if(model.hasBonus && !model.hasMalus){
			translation = Time.deltaTime * ( model.moveSpeed + model.bonusMooveSpeed );
		}else if(!model.hasBonus && model.hasMalus){
			 translation = Time.deltaTime * ( model.moveSpeed - model.malusMooveSpeed );
		}else if(!model.hasBonus && !model.hasMalus){
			 translation = Time.deltaTime * model.moveSpeed;
		}else if(model.hasBonus && model.hasMalus){
			// Si le joueur a un bonus ET un malus il devien fouuuu ! Il pete un cable genre il bouge cheloument et tout (cest une idee hein)
			Debug.Log(Random.value > 0.5f );
			translation = Time.deltaTime * ( model.moveSpeed + Random.Range(-10, 15) );
			 // translation =  Random.value > 0.5f ? Time.deltaTime * ( model.moveSpeed - 15 ) : Time.deltaTime * ( model.moveSpeed + 9 );
		}


		if (Input.GetKey (KeyCode.Space)) {
			this.throwPower ();
		}
		if (Input.GetKey (KeyCode.V)) {
			this.shoot ();
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (new Vector3 (-translation, 0, 0));
			Vector3 newScale = transform.localScale;
			newScale.x *= -newScale.x;
			transform.localScale = newScale;

		} else if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (new Vector3 (translation, 0, 0));
			Vector3 newScale = transform.localScale;
			newScale.x *= newScale.x;
			transform.localScale = newScale;
		
		} 

		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Translate (new Vector3 (0, translation, 0));
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Translate (new Vector3 (0, -translation, 0));
		}
		//Zak
		//Zak	
	}

	void throwPower(){
    	Debug.Log("power");
		if(model.hasBonus){
			model.power.direction = (int) transform.localScale.x;
			Instantiate (model.power, model.shootPoint.position, model.shootPoint.rotation);
			// model.power 	= null;
			model.hasBonus 	= false;
		}
	}

	void shoot(){
		if (model.fireRate == 0) {
			this.instatiateTir ();
		} else {
			if(Time.time > model.timeToFire){
				model.timeToFire = Time.time + 1 / model.fireRate;
				this.instatiateTir();
			}
		}
	}

	void instatiateTir(){
		Debug.Log (model.tir);
		model.tir.direction = (int) transform.localScale.x;
		Instantiate (model.tir, model.shootPoint.position, model.shootPoint.rotation);
	}
		
	
}
