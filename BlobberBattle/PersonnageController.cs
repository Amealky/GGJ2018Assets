using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageController : MonoBehaviour {

	private PersonnageModel model;
	private string horizontalAxis;
	private string verticalAxis;
	private string buttonX;
	private string triggerAxis;

    private Vector3 initialPositionJ1 = new Vector3(-117, 77,0);
    private Vector3 initialPositionJ2 = new Vector3(27, 77, 0);

    public AudioClip tirNormal;
    public AudioClip degatsNormaux;
    public AudioClip tirSpeciaux;
    public AudioClip degatsSpeciaux;
    public AudioClip Mort;
    private AudioSource source;
    private float volumecourtedistance = .5f;
    private float volumelonguedistance = 1.0f;

    void Awake(){
		model = this.gameObject.GetComponent<PersonnageModel> ();
	}

	// Use this for initialization

	void Start () {
		model.sprite = this.gameObject.GetComponent<SpriteRenderer> ();
		model.shootPoint = transform.Find ("ShootPoint");
		// model.power = this.gameObject.GetComponent<Power> ();

		model.power = this.gameObject.GetComponent<BonusThrowedScript> ();
		model.tir = this.gameObject.GetComponent<Tir> ();


		horizontalAxis = "J" + model.numeroJoueur + "Horizontal";
		verticalAxis = "J" + model.numeroJoueur + "Vertical";
		buttonX = "J" + model.numeroJoueur + "X";
		triggerAxis = "J" + model.numeroJoueur + "Trigger"; 

		model.anim = this.gameObject.GetComponent<Animator> ();
        //Zak
        //Zak

        model.life = 3;

        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {

		model.deltime = Time.time;
		if ((model.deltime - model.timeSaved) > model.animationTime){
			model.isShot = false;
		}
		if (model.isShot) {
			model.valRecul = (model.recul*model.percentage) * (int) transform.localScale.x;
			Vector2 temp = new Vector2 (transform.position.x-model.valRecul,transform.position.y); // On fait un vecteur qui le déplace vers la gauche
			transform.position = Vector2.Lerp (transform.position, temp,Time.fixedDeltaTime);

		}
	/*	model.hasMalus = true;

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
*/

		if (model.isMoving && !model.isAttacking) {
			model.anim.Play ("Marche");
		} else if(!model.isAttacking) {
			model.anim.Play ("Idle");
		}
			
		if (Input.GetKey (KeyCode.UpArrow)) { 
			this.throwPower ();
		}
		if (Input.GetButton(buttonX) ) {
			this.throwPower ();
		}
		if (Input.GetAxis(triggerAxis) < 0.0) {
			//this.shoot ();
			model.isAttacking = true;
			model.anim.Play ("Crachat");
		}


		if (Input.GetAxis (horizontalAxis) != 0.0) {
			float speed = Input.GetAxis (horizontalAxis) * model.moveSpeed;

			//transform.position = transform.position + inputDirection;
			transform.Translate (speed, 0, 0);

			model.isMoving = true;

		} 

		if (Input.GetAxis(verticalAxis) != 0.0) {
			Vector3 inputDirection = Vector3.zero;
			inputDirection.y = -(Input.GetAxis (verticalAxis) * model.moveSpeed);
			transform.position = transform.position + inputDirection;
			model.isMoving = true;
		}

		if (Input.GetAxis (verticalAxis) == 0.0 && Input.GetAxis (horizontalAxis) == 0.0) {
			model.isMoving = false;
		}

		/*if (Input.GetKey (KeyCode.LeftArrow)) { 
			transform.Translate (new Vector3 (-translation, 0, 0)); 
			//model.sprite.flipX = true; 
			Vector3 newScale = transform.localScale; 
			newScale.x *= -newScale.x; 
			transform.localScale = newScale; 

		} else if (Input.GetKey (KeyCode.RightArrow)) { 
			transform.Translate (new Vector3 (translation, 0, 0)); 

			//model.sprite.flipX = false; 
			Vector3 newScale = transform.localScale; 
			newScale.x *= newScale.x; 
			transform.localScale = newScale; 


		}  

		if (Input.GetKey (KeyCode.UpArrow)) { 
			transform.Translate (new Vector3 (0, translation, 0)); 
		} else if (Input.GetKey (KeyCode.DownArrow)) { 
			transform.Translate (new Vector3 (0, -translation, 0)); 
		} */

		//Zak
		//Zak	
	}

	void throwPower(){
    
		if(model.hasBonus){
			model.power.direction = (int) transform.localScale.x;
			Vector3 instantiatePosition = new Vector3(gameObject.name == "Joueur1" ? model.shootPoint.position.x+5 : model.shootPoint.position.x-5, model.shootPoint.position.y, model.shootPoint.position.z);
			Instantiate (model.power, instantiatePosition, model.shootPoint.rotation);
			model.power 	= null;
			model.hasBonus 	= false;
			model.moveSpeed -= model.speedAffection;
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

	void endShoot(){
		model.isAttacking = false;
	}

	void instatiateTir(){
		//Debug.Log (model.tir);
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
		
	//Zak
	void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.tag == "Bonus"){
			Debug.Log("Bonus ramaser");
            pickUpBonus();
			model.speedAffection = other.GetComponent<BonusScript> ().speed;
			applyEffect ();
		}
        if (other.gameObject.tag == "Vide")
        {
            Debug.Log("vide!");
            if (gameObject.name == "Joueur1")
            {
                transform.position = initialPositionJ1;
            }
            if (gameObject.name == "Joueur2")
            {
                transform.position = initialPositionJ2;
            }
            model.life--;
            Debug.Log(gameObject.name + " a:" + model.life);
        }

        if (other.gameObject.tag == "Limite")
        {
            Debug.Log("bloque gauche");
        }

        if (other.gameObject.tag == "Mur Haut")
        {
            Debug.Log("bloque haut");
        }

        if (other.gameObject.tag == "Mur Bas")
        {
            Debug.Log("bloque bas");
        }

        if (other.gameObject.tag == "BonusThrowed") {
			Debug.Log ("ThrowedTag");
			model.hasMalus = true;
			model.speedAffection = other.GetComponent<BonusThrowedScript> ().speedAffection;
			applyEffect ();
			Destroy (other.gameObject);
		}


		Tir shot = other.gameObject.GetComponent<Tir> ();
		if (shot != null) { // Si l'objet qui le touche contient le scrip BulletBehavior
			
			model.percentage+=shot.bulletDamage; // On augmente les pourcentages du nombre de dégat de la balle
			model.isShot = true; // On déclare que le joueur se fait toucher.
			model.timeSaved = Time.time;
		}
	}

	void tombeDansLeVide(){
		Destroy(gameObject);
	}

	void pickUpBonus(){
		model.hasBonus = true;
	}

	IEnumerator LoadChangeBonusToMalus(float temps){
		yield return new WaitForSeconds (temps);
		if (model.hasBonus) {
			youAreFucked ();
		}


	}

	IEnumerator LoadEndMalus(float temps){
		yield return new WaitForSeconds (temps);
		model.hasMalus = false;
		applyEffect ();

	}

	void applyEffect(){
		if (model.hasBonus) {
			model.moveSpeed += model.speedAffection;
			StartCoroutine (LoadChangeBonusToMalus (5.0f));
			model.sprite.color = Color.green;
			Debug.Log ("Bonus");
		} 

		if(model.hasMalus){
			model.moveSpeed -= model.speedAffection;
			StartCoroutine (LoadEndMalus (5.0f));
			model.sprite.color = Color.red;
			Debug.Log ("Malus");
		}

		if (!model.hasMalus && !model.hasBonus) {
			model.moveSpeed = model.speedBase;
			Debug.Log ("Fin de malus");
			model.sprite.color = Color.white;
		}


	}

	void youAreFucked(){
		model.hasBonus = false;
		model.hasMalus = true;
		model.speedAffection *= 2;
		model.power = null;
		applyEffect ();
	}
		


	public PersonnageModel getModel(){
		return this.model;
	}
	//Zak
	
}
