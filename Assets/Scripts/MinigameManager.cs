using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour {

    public float numWeedsPulled;
    public Slider progressBar;
    public Text progressText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (numWeedsPulled == 5)
        {
            Debug.Log("YOU'RE WINRAR");
        }
        progressBar.value = numWeedsPulled;
        progressText.text = progressBar.value + "/5";
	}
}
