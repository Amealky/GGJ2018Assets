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


	private GameObject Player1LifesLeft;
	private GameObject Player2LifesLeft;



	private GameObject Player1TimeBeforeGetFucked;
	private GameObject Player2TimeBeforeGetFucked;
	private string PlayerName;
	private float lastPercentagePlayer1;
	private float lastPercentagePlayer2;

	// Use this for initialization
	void Start () {
		PlayerName	= "Perso";
		Player1LifesLeft 	= GameObject.Find("Player1LifesLeft");
		Player2LifesLeft 	= GameObject.Find("Player2LifesLeft");

		Player1Percentage 	= GameObject.Find("Player1Percentage");
		Player2Percentage 	= GameObject.Find("Player2Percentage");
		Player1HasBonus 	= GameObject.Find("Player1HasBonus");
		Player2HasBonus 	= GameObject.Find("Player2HasBonus");
		Player1HasMalus 	= GameObject.Find("Player1HasMalus");
		Player2HasMalus 	= GameObject.Find("Player2HasMalus");

		Player1TimeBeforeGetFucked 	= GameObject.Find("Player1TimeBeforeGetFucked");
		Player2TimeBeforeGetFucked 	= GameObject.Find("Player2TimeBeforeGetFucked");
	}
	
	// Update is called once per frame
	void Update () {
		updateBonusUI();
		updatePercentageUI();
		updateMalusUI();
		updateLifeleft();
	}

	void updateLifeleft(){
		if(GameObject.Find("Joueur1") != null){
			PersonnageController Script1 = GameObject.Find("Joueur1").GetComponent<PersonnageController>();
			Player1LifesLeft.GetComponent<UnityEngine.UI.Text>().text = Script1.getModel().life + "";	
		}
	
		if(GameObject.Find("Joueur2") != null){
			PersonnageController Script2 = GameObject.Find("Joueur2").GetComponent<PersonnageController>();
			Player2LifesLeft.GetComponent<UnityEngine.UI.Text>().text = Script2.getModel().life + "";
		}
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
				ShakeUi shakeScript2 = Player2Percentage.GetComponent<ShakeUi>();
				shakeScript2.ShakeIt(10+(lastPercentagePlayer2/7), 0.5f);
				lastPercentagePlayer2 = Script2.getModel().percentage; 
			}
		}
	}

	void updateBonusUI(){
		if(GameObject.Find("Joueur1") != null){
			PersonnageController Script1 = GameObject.Find("Joueur1").GetComponent<PersonnageController>();
			Player1HasBonus.active = Script1.getModel().hasBonus;
			Player1TimeBeforeGetFucked.GetComponent<UnityEngine.UI.Text>().text = Script1.getModel().timeBeforeGetFucked+""; 
		}
		if(GameObject.Find("Joueur2") != null){
			PersonnageController Script2 = GameObject.Find("Joueur2").GetComponent<PersonnageController>();
			Player2HasBonus.active = Script2.getModel().hasBonus;
			Player2TimeBeforeGetFucked.GetComponent<UnityEngine.UI.Text>().text = Script2.getModel().timeBeforeGetFucked+""; 
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
