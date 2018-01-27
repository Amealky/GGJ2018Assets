using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageModel : MonoBehaviour {

	//Zak
	/*public float bonusMooveSpeed;
	public float malusMooveSpeed;*/
	//Zak
	public float percentage = 1;
	public float attackSpeed;
	public float moveSpeed;
	public int life;
	public bool isShooting { get; set;}
	public BonusThrowedScript power;
	public Tir tir;
	public bool isMoving  { get; set;}
	public bool isAttacking  { get; set;}
	public SpriteRenderer sprite { get; set;}
	public Transform shootPoint;
	public float fireRate = 0;
	public float timeToFire = 0;
	public float damage = 5;
	public bool hasBonus = false;
	public bool hasMalus = false;
	public Animator anim { get; set; }

	public float recul = 0.5f;
	public bool isShot = false;
	public float valRecul = 0.1f ;
	public float timeSaved { get; set;}
	public float deltime { get; set;}
	public float animationTime = 0.5f;

	public float numeroJoueur = 1;


	//Zak
	//Zak


}
