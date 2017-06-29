using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeviScript : MonoBehaviour {

    public GameObject gardenButton;
    public GameObject scannerCanvas;
    public GameObject questsCanvas;
    public GameObject toolShedCanvas;
    public GameObject plantCuttingCanvas;
    public GameObject compostCanvas;
    public GameObject questCompleteCanvas;
    public GameObject collectSecateursCanvas;
    public GameObject trimPlantsCanvas;

    public Toggle taskOne;
    public Toggle taskTwo;
    public Toggle taskThree;
    public Toggle taskFour;
    public Toggle taskFive;

    public bool collectedSecateurs;
    public GameObject secateurs;

    public bool plantHasBeenCut;
    public bool compostMade;
    public int plantScraps = 5;
    public Text plantScrapNumText;

    public GameObject bushManager;

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

        if (plantHasBeenCut)
        {
            taskTwo.isOn = true;
        }


        if (compostMade)
        {
            taskThree.isOn = true;
        }
                
        if(plantScraps < 0)
        {
            plantScraps = 0;
        }

        plantScrapNumText.text = "x" + (int)plantScraps;
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
    public void toolShedButtonPressed()
    {
        scannerCanvas.SetActive(false);
        questsCanvas.SetActive(false);
        toolShedCanvas.SetActive(true);
    }
    public void plantCuttingButtonPressed()
    {
        if (collectedSecateurs)
        {
            scannerCanvas.SetActive(false);
            questsCanvas.SetActive(false);
            plantCuttingCanvas.SetActive(true);
        }
        if (!collectedSecateurs)
        {
            collectSecateursCanvas.SetActive(true);
        }    
    }
    public void compostButtonPressed()
    {
        if (plantHasBeenCut)
        {
            scannerCanvas.SetActive(false);
            questsCanvas.SetActive(false);
            compostCanvas.SetActive(true);
        }
        if (!plantHasBeenCut)
        {
            trimPlantsCanvas.SetActive(true);
        }
    }
    public void exitToolShedButton()
    {
        toolShedCanvas.SetActive(false);
        scannerCanvas.SetActive(true);
    }
    public void exitPlantCuttingButton()
    {
        plantCuttingCanvas.SetActive(false);
        scannerCanvas.SetActive(true);

        if(bushManager.gameObject.GetComponent<MinigameManager>().objectivesCompleted >= 5)
        {
            plantHasBeenCut = true;
        }
    }
    public void exitCompostBinButton()
    {
        compostCanvas.SetActive(false);
        scannerCanvas.SetActive(true);
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
        taskOne.isOn = false;
        taskTwo.isOn = false;
        taskThree.isOn = false;
        //taskFour.isOn = false;
        //taskFive.isOn = false;
        collectedSecateurs = false;
        plantHasBeenCut = false;
        compostMade = false;        
        questCompleteCanvas.SetActive(false);
    }

    public void trimPlantsClose()
    {
        trimPlantsCanvas.SetActive(false);
        
    }
    public void collectSecateursClose()
    {
        collectSecateursCanvas.SetActive(false);
        
    }

    public void collectSecateurs()
    {
        collectedSecateurs = true; 
    }

    public void dropPlantScraps()
    {
        plantScraps -= 1;
        compostMade = true;
    }

}
