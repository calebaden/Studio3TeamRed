using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GenderSelectButton : MonoBehaviour {
	public bool isMaleButton = false;
	public GameObject createButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick()
	{
		if(isMaleButton)
		{
			//Set the Gender to male
			if(createButton.GetComponent<UI_SetUpAccount>() != null)
				createButton.GetComponent<UI_SetUpAccount>().genderEntry = 1;
		}
		else{
			// Set the gender to male
			if(createButton.GetComponent<UI_SetUpAccount>() != null)
				createButton.GetComponent<UI_SetUpAccount>().genderEntry = 2;
		}
	}
}
