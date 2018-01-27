using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonnageModel : MonoBehaviour {

	public float percentage;
	public float attackSpeed;
	public float moveSpeed;
	public int life;
	public bool hasBonus { get; set;}
	public bool hasMalus { get; set;}
	public bool isShooting { get; set;}
	public Power power;
	public Tir tir;
	public bool isMoving  { get; set;}
	public SpriteRenderer sprite { get; set;}
	public Transform shootPoint;
	public float fireRate = 0;
	public float timeToFire = 0;
	public float damage = 5;


	//Zak
	//Zak


}
