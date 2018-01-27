using System.Collections;
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
	private float lastPercentagePlayer1;
	private float lastPercentagePlayer2;

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


	void updatePercentageUI(){
		if(GameObject.Find("Joueur1") != null){
			PersonnageController Script1 = GameObject.Find("Joueur1").GetComponent<PersonnageController>();
			Player1Percentage.GetComponent<UnityEngine.UI.Text>().text = Script1.getModel().percentage + "%";	
			if( lastPercentagePlayer1 != Script1.getModel().percentage ){
				ShakeUi shakeScript = Player1Percentage.GetComponent<ShakeUi>();
				shakeScript.ShakeIt(10+(lastPercentagePlayer1/7), 0.5f);
				lastPercentagePlayer1 = Script1.getModel().percentage; 
			}
		}
	
		if(GameObject.Find("Joueur2") != null){
			PersonnageController Script2 = GameObject.Find("Joueur2").GetComponent<PersonnageController>();
			Player2Percentage.GetComponent<UnityEngine.UI.Text>().text = Script2.getModel().percentage + "%";
			if( lastPercentagePlayer2 != Script2.getModel().percentage ){
				ShakeUi shakeScript2 = Player1Percentage.GetComponent<ShakeUi>();
				shakeScript2.ShakeIt(10+(lastPercentagePlayer2/7), 0.5f);
				lastPercentagePlayer1 = Script2.getModel().percentage; 
			}
		}
	}

	void updateBonusUI(){
		if(GameObject.Find("Joueur1") != null){
			PersonnageController Script1 = GameObject.Find("Joueur1").GetComponent<PersonnageController>();
			Player1HasBonus.active = Script1.getModel().hasBonus;
		}
		if(GameObject.Find("Joueur2") != null){
			PersonnageController Script2 = GameObject.Find("Joueur2").GetComponent<PersonnageController>();
			Player2HasBonus.active = Script2.getModel().hasBonus;
		}
	}

	void updateMalusUI(){
		if(GameObject.Find("Joueur1") != null){
			PersonnageController Script1 = GameObject.Find("Joueur1").GetComponent<PersonnageController>();
			Player1HasMalus.active = Script1.getModel().hasMalus;
		}
	
		if(GameObject.Find("Joueur2") != null){
			PersonnageController Script2 = GameObject.Find("Joueur2").GetComponent<PersonnageController>();
			Player2HasMalus.active = Script2.getModel().hasMalus;
		}
	}

}
