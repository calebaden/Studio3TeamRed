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
    private GameObject moreInfo;
    [SerializeField]
    private Text seeds;
    [SerializeField]
    private Text plantTitle;
    [SerializeField]
    private Text infoTitle;

    public GardenPlotScript selectedPlot;
    public Texture2D waterCursor;

    public Slider growthSlider;
    public Slider waterSlider;

    public int seedCount;

    private bool isWatering = false;
    private bool isHovering;

    // Use this for initialization
    void Start ()
    {
        seedSelect.SetActive(false);
        plantInfo.SetActive(false);
        moreInfo.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (plantInfo.activeSelf == true && selectedPlot != null)
        {
            growthSlider.value = selectedPlot.growthAmount;
            waterSlider.value = selectedPlot.waterAmount;
        }

        seeds.text = seedCount + " X";

        if (isHovering && Input.GetMouseButton(0))
        {
            selectedPlot.WaterPlant();
        }
	}

    // Enables the seed select window if it is currently disabled
    public void SelectPlot (GameObject plot)
    {
        if (plantInfo.gameObject.activeSelf == false)
        {
            selectedPlot = plot.GetComponent<GardenPlotScript>();
            if (!isWatering)
            {
                if (selectedPlot.plotState == 0)
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
                        if (selectedPlot.plantType == "Sunflower")
                        {
                            plantTitle.text = "Sunflower";
                        }
                        else if (selectedPlot.plantType == "Carrot")
                        {
                            plantTitle.text = "Carrot";
                        }
                    }
                }
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
            selectedPlot.UpdatePlant(type);
            seedCount--;
            CloseWindow(seedSelect);
        }
        else
        {
            Debug.Log("You have no seeds!");
        }
    }

    public void OnWaterClick ()
    {
        if (!isWatering)
        {
            isWatering = true;
            Cursor.SetCursor(waterCursor, Vector2.zero, CursorMode.Auto);
            foreach (GameObject plot in GameObject.FindGameObjectsWithTag("GardenPlot"))
            {
                if (plot.GetComponent<GardenPlotScript>().plotState != 0)
                {
                    plot.GetComponent<GardenPlotScript>().plotWater.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            isWatering = false;
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            foreach (GameObject plot in GameObject.FindGameObjectsWithTag("GardenPlot"))
            {
                if (plot.GetComponent<GardenPlotScript>().plotWater.gameObject.activeSelf)
                {
                    plot.GetComponent<GardenPlotScript>().plotWater.gameObject.SetActive(false);
                }
            }
        }
    }

    public void WaterEnter (GameObject plot)
    {
        if (plantInfo.gameObject.activeSelf == false)
        {
            selectedPlot = plot.GetComponent<GardenPlotScript>();
            if (selectedPlot.plotState != 0)
            {
                isHovering = true;
            }
        }
    }

    public void WaterExit ()
    {
        isHovering = false;
    }

    public void MoreInfo ()
    {
        if (selectedPlot.plantType == "Sunflower")
        {
            infoTitle.text = "Sunflower";
        }
        else
        {
            infoTitle.text = "Carrot";
        }

        moreInfo.gameObject.SetActive(true);
    }
}
