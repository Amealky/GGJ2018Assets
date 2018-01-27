using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageController : MonoBehaviour {

	private PersonnageModel model;
	private string horizontalAxis;
	private string verticalAxis;
	private string buttonX;
	private string triggerAxis;
	

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

		/*	private string horizontalAxis;
	private string verticalAxis;
	private string buttonX;
	private string triggerAxis;*/
		horizontalAxis = "J" + model.numeroJoueur + "Horizontal";
		verticalAxis = "J" + model.numeroJoueur + "Vertical";
		buttonX = "J" + model.numeroJoueur + "X";
		triggerAxis = "J" + model.numeroJoueur + "Trigger";


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
			
		if (Input.GetButton("ButtonBSpecialShoot")) {
			Debug.Log ("BUTTONB");
			this.throwPower ();
		}
		if (Input.GetAxis("TriggerShoot") < 0.0) {
			Debug.Log ("shoot");
			this.shoot ();
		}



		if (Input.GetAxis("LeftJoystickX") != 0.0) {
			Vector3 inputDirection = Vector3.zero;
			inputDirection.x = Input.GetAxis ("LeftJoystickX") * model.moveSpeed;
			transform.position = transform.position + inputDirection;
			if (inputDirection.x < 0.0) {
				this.flipLeft (translation);
			} else {
				this.flipRight (translation);
			}
		}

		if (Input.GetAxis("LeftJoystickY") != 0.0) {
			Vector3 inputDirection = Vector3.zero;
			inputDirection.y = -(Input.GetAxis ("LeftJoystickY") * model.moveSpeed);
			transform.position = transform.position + inputDirection;
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
    
		//if(model.hasBonus){
			model.power.direction = (int) transform.localScale.x;
			Instantiate (model.power, model.shootPoint.position, model.shootPoint.rotation);
			model.power 	= null;
			model.hasBonus 	= false;
		//	}
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

	void flipRight(float translation){
		transform.Translate (new Vector3 (translation, 0, 0));
		Vector3 newScale = transform.localScale;
		newScale.x *= newScale.x;
		transform.localScale = newScale;
	}

	void flipLeft(float translation){
		transform.Translate (new Vector3 (-translation, 0, 0));
		Vector3 newScale = transform.localScale;
		newScale.x *= -newScale.x;
		transform.localScale = newScale;
	}
		
	
}
