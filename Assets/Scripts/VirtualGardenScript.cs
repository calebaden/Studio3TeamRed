using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VirtualGardenScript : MonoBehaviour
{
    VirtualGardenScript virtualGardenScr;

    [SerializeField]
    private GameObject seedSelect;
    [SerializeField]
    private GameObject plantInfo;
    [SerializeField]
    private Text seeds;

    public GameObject selectedPlot;

    public Slider growthSlider;

    public int seedCount;

    // Use this for initialization
    void Start ()
    {
        seedSelect.SetActive(false);
        plantInfo.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (plantInfo.activeSelf == true && selectedPlot != null)
        {
            growthSlider.value = selectedPlot.GetComponent<GardenPlotScript>().growthAmount;
        }

        seeds.text = seedCount + " X";
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
        else
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
        if (seedCount > 0)
        {
            selectedPlot.GetComponent<GardenPlotScript>().UpdatePlant(type);
            seedCount--;
            CloseWindow(seedSelect);
        }
        else
        {
            Debug.Log("You have no seeds!");
        }
    }
}
