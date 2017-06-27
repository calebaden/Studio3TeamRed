using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VirtualGardenScript : MonoBehaviour
{
    VirtualGardenScript virtualGardenScr;

    [SerializeField]
    private GameObject seedSelect;
    [SerializeField]
    private GameObject plantInfo;

    public GameObject selectedPlot;

    // Use this for initialization
    void Start ()
    {
        seedSelect.SetActive(false);
        plantInfo.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void LoadScene (int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    // Enables the seed select window if it is currently disabled
    public void SelectPlot (GameObject plot)
    {
        selectedPlot = plot;
        if (selectedPlot.GetComponent<GardenPlotScript>().plotState == 0)
        {
            if (seedSelect.activeSelf == false)
            {
                seedSelect.SetActive(true);
            }
        }
        else if (selectedPlot.GetComponent<GardenPlotScript>().plotState == 1)
        {
            if (plantInfo.activeSelf == false)
            {
                plantInfo.SetActive(true);
            }
        }
    }

    // Disbales the seed select window if it is currently enabled
    public void CloseWindow (GameObject window)
    {
        if (window.activeSelf == true)
        {
            window.SetActive(false);
        }
    }

    public void PlantSeed (int type)
    {
        selectedPlot.GetComponent<GardenPlotScript>().UpdatePlant(type);
        CloseWindow(seedSelect);
    }
}
