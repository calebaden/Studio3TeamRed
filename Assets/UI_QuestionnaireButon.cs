using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_QuestionnaireButon : MonoBehaviour {
	public int thisResult;

	public ResponseChecker responseChecker;

	public void OnClick()
	{
		responseChecker.SelectedResult = thisResult;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
