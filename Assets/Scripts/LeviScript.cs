using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeviScript : MonoBehaviour {

    public GameObject gardenButton;
    public GameObject scannerCanvas;
    public GameObject questsCanvas;
    public GameObject miniGameCanvas;
    public GameObject questCompleteCanvas;

    public Toggle taskOne;
    public Toggle taskTwo;
    public Toggle taskThree;
    public Toggle taskFour;
    public Toggle taskFive;

    public bool collectedSecateurs;
    public GameObject secateurs;

    // Use this for initialization
    void Start()
    {
        collectedSecateurs = false;
    }

    // Update is called once per frame
    void Update()
    {
        questComplete();

        if (collectedSecateurs)
        {
            secateurs.SetActive(false);
            taskOne.isOn = true;
        }
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
        
    public void taskTwoComplete()
    {
        taskTwo.isOn = true;
    }
    public void taskThreeComplete()
    {
        taskThree.isOn = true;
    }  

    public void questComplete()
    {
        if (taskOne.isOn == true && taskTwo.isOn == true && taskThree.isOn == true)
        {
            questCompleteCanvas.SetActive(true);
        }
    }
    public void questCompleteClose()
    {
        questCompleteCanvas.SetActive(false);
        taskOne.isOn = false;
        taskTwo.isOn = false;
        taskThree.isOn = false;
        taskFour.isOn = false;
        taskFive.isOn = false;
    }

    public void collectSecateurs()
    {
        collectedSecateurs = true; 
    }

}
