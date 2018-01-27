using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	public float pourcentage = 0;
	public float recul=0.1f;
	public bool isShot = false;
	public float valRecul = 0.1f;

	// Update is called once per frame
	void Update () {
		//if (isShot){ // Si on se fait toucher 
			valRecul = recul*pourcentage;
			Vector2 temp = new Vector2 (transform.position.x-valRecul,transform.position.y);//-valRecul,transform.position.y); // On fait un vecteur qui le déplace vers la gauche
				transform.position = Vector2.Lerp (transform.position, temp,1f);//Time.fixedDeltaTime);
			//transform.position = temp; //Vector2.Lerp(transform.position,temp,0.5f); // On lui donne sa nouvelle coordonnée
			isShot = false; // Le tir est terminée
		//}
	}

	void OnTriggerEnter2D(Collider2D collider){
		BulletBehavior shot = collider.gameObject.GetComponent<BulletBehavior> ();
		if (shot != null) { // Si l'objet qui le touche contient le scrip BulletBehavior
			pourcentage+=shot.bulletDamage; // On augmente les pourcentages du nombre de dégat de la balle
			isShot = true; // On déclare que le joueur se fait toucher.

			}
	}
}
