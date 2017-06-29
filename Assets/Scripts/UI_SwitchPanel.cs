using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UI_SwitchPanel : MonoBehaviour {
    public GameObject DestinationPanel;
    public GameObject thisPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick()
	{
		Debug.Log("Going to the " + DestinationPanel.name + " screen.");
        DestinationPanel.SetActive(true);
        thisPanel.SetActive(false);

	}
}
