using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeviScript : MonoBehaviour {

    public GameObject gardenButton;
    public GameObject scannerCanvas;
    public GameObject questsCanvas;
    public GameObject miniGameCanvas;

    public Toggle taskOne;
    public Toggle taskTwo;
    public Toggle taskThree;
    public Toggle taskFour;
    public Toggle taskFive;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void gardenButtonPressed()
    {

    }

    public void questsButtonPressed()
    {
        scannerCanvas.SetActive(false);
        questsCanvas.SetActive(true);
    }

    public void scannerButtonPressed()
    {
        questsCanvas.SetActive(false);
        scannerCanvas.SetActive(true);
    }

    public void minigameButtonPressed()
    {
        scannerCanvas.SetActive(false);
        questsCanvas.SetActive(false);
        miniGameCanvas.SetActive(true);
    }

    public void exitMiniGameButton()
    {
        miniGameCanvas.SetActive(false);
        scannerCanvas.SetActive(true);
    }

    public void taskOneComplete()
    {
        taskOne.isOn = true;
    }

    public void taskTwoComplete()
    {
        taskTwo.isOn = true;
    }

    public void taskThreeComplete()
    {
        taskThree.isOn = true;
    }

    public void taskFourComplete()
    {
        taskFour.isOn = true;
    }
    public void taskFiveComplete()
    {
        taskFive.isOn = true;
    }

}
