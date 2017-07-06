using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResponseChecker : MonoBehaviour {
	// This script will compare integers to buttons within an array to check if a button is the "correct" button

	public int DesiredResult;

	public int SelectedResult;

	public GameObject correctPanel;
	public GameObject incorrectPanel;
	public GameObject thisQuestionnairePanel;

	//public UI_SwitchPanel thisSwitchPanelScript;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick()
	{
		//Check if the answer is correct
		if(SelectedResult == DesiredResult)
		{
			Debug.Log("Response is correct");

			//Switch to the Quests Scene
			correctPanel.SetActive(true);
			thisQuestionnairePanel.SetActive(false);
		}
		else
		{
			Debug.Log("Response is incorrect");
			//Switch to the Quests Scene
			incorrectPanel.SetActive(true);
			thisQuestionnairePanel.SetActive(false);
			//Switch to the weed pulling game
		}
	}
}
