/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDScript : MonoBehaviour {

	private GameObject Player1Percentage;
	private GameObject Player2Percentage;
	private GameObject Player1HasBonus;
	private GameObject Player2HasBonus;
	private GameObject Player1HasMalus;
	private GameObject Player2HasMalus;
	private string PlayerName;
	// Use this for initialization
	void Start () {
		PlayerName	= "Perso";
		Player1Percentage 	= GameObject.Find("Player1Percentage");
		Player2Percentage 	= GameObject.Find("Player2Percentage");
		Player1HasBonus 	= GameObject.Find("Player1HasBonus");
		Player2HasBonus 	= GameObject.Find("Player2HasBonus");
		Player1HasMalus 	= GameObject.Find("Player1HasMalus");
		Player2HasMalus 	= GameObject.Find("Player2HasMalus");
	}
	
	// Update is called once per frame
	void Update () {
		updateBonusUI();
		updatePercentageUI();
		updateMalusUI();
	}


	void updateBonusUI(){
		Player1HasBonus.active = false;
		Player2HasBonus.active = false;
	}

	void updatePercentageUI(){
		Player1Percentage.GetComponent<UnityEngine.UI.Text>().text = GameObject.Find("Joueur1").GetComponent<PersonnageController>().percentage + "%";
		Player2Percentage.GetComponent<UnityEngine.UI.Text>().text = GameObject.Find("Joueur1").GetComponent<PersonnageController>().percentage + "%";
	}

	void updateMalusUI(){
		Player1HasMalus.active = false;
		Player2HasMalus.active = false;
	}

}
*/