using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// This script is placed on the parent panel of the virtual garden
public class VirtualGardenScript : MonoBehaviour
{
    [SerializeField]
    private GameObject seedSelect;          // GameObject with all of the 'seed select' window components
    [SerializeField]
    private GameObject plantInfo;           // GameObject with all of the 'plant information' window components
    [SerializeField]
    private GameObject moreInfo;            // GameObject with all of the 'more information' window components
    [SerializeField]
    private Text seeds;                     // Text field displaying the players seed inventory count
    [SerializeField]
    private Text plantTitle;                // Text field displaying the plant title in the plantInfo window
    [SerializeField]
    private Text infoTitle;                 // Text field displaying the plant title in the moreInfo window

    public GardenPlotScript selectedPlot;   // Instance of the GardenPlotScript
    public Texture2D waterCursor;           // Cursor texture for watering plants

    public Slider growthSlider;             // Slider showing the growth percentage of a plant in the plantInfo window
    public Slider waterSlider;              // Slider showing the water amount of a plant in the plantInfo window
    public Slider weedSlider;               // Slider showing the amount of weeds currently populating the garden

    public Image weedSliderFill;            // Image for the fill area located on the weedSlider
    public float weedGrowth;                // The rate at which the weeds grow
    public int weedSliderMaxRed;            // This is the max Red value of the weed slider fill colour
    public GameObject weedWarning;          // Includes the warning image and text displayed when weeds are overgrown
    public GameObject weedMinigame;         // Prefab of weed minigame

    public int seedCount;                   // Integer storing the players seed inventory count

    private bool isWatering = false;        // Bool that changes whether it is in watering mode or not
    private bool isHovering;                // Bool that changes when the mouse enters a plot button

    // Use this for initialization
    void Start ()
    {
        // Disable all of the closed windows
        seedSelect.SetActive(false);
        plantInfo.SetActive(false);
        moreInfo.SetActive(false);
        weedWarning.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        // If the plant info window is open and there is a selected plot, set the slider values to their respective variables
		if (plantInfo.activeSelf == true && selectedPlot != null)
        {
            growthSlider.value = selectedPlot.growthAmount;
            waterSlider.value = selectedPlot.waterAmount;
        }

        // Change the seeds text content to reflect the seed count variable
        seeds.text = seedCount + " X";

        // When the player clicks down on a plot, call the WaterPlant function
        if (isHovering && Input.GetMouseButton(0))
        {
            selectedPlot.WaterPlant();
        }

        // Increase the amount of weeds over time; when at maximum, enable the warning window
        if (weedSlider.value < 1)
        {
            weedSlider.value += weedGrowth * Time.deltaTime;
            weedSlider.value = Mathf.Clamp01(weedSlider.value);
        }
        else if (!weedWarning.activeSelf)
        {
            weedWarning.SetActive(true);
        }

        // Sets the weed slider fill color depending on its value; 1 = green, 0 = dark green/yellow
        Color col = weedSliderFill.color;
        col.r = weedSlider.value * weedSliderMaxRed;
        col.r /= 255;
        weedSliderFill.color = col;
	}

    // Function called when a player uses the garden plot buttons
    public void SelectPlot (GameObject plot)
    {
        if (plantInfo.gameObject.activeSelf == false)
        {
            // If the plant info window is disabled, update the selected plot with the button that was pressed
            selectedPlot = plot.GetComponent<GardenPlotScript>();
            if (!isWatering)
            {
                if (selectedPlot.plotState == 0)
                {
                    // If the garden is not in watering mode & the plot has no plant, enable the seed select window 
                    if (seedSelect.activeSelf == false)
                    {
                        seedSelect.SetActive(true);
                    }
                }
                else
                {
                    // If the garden is not in watering mode & the plot does have a plant, enable the plant info window
                    if (plantInfo.activeSelf == false)
                    {
                        plantInfo.SetActive(true);
                        // Change the plant info title text to be equal to the plots plant type
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

    // Disbales the given game object
    public void CloseWindow (GameObject window)
    {
        if (window.activeSelf == true)
        {
            window.SetActive(false);
        }
    }

    // Function used for the buttons in the seed select window
    public void PlantSeed (int type)
    {
        // If the player has a seed call the UpdatePlant function from the plot, decrement seed count and close the seed select window
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

    // Function called when clicking on the watering button
    public void OnWaterClick ()
    {
        if (!isWatering)
        {
            // If watering mode is disabled, set it to true and replace the cursor
            isWatering = true;
            Cursor.SetCursor(waterCursor, Vector2.zero, CursorMode.Auto);
            // For every plot that has a plant in it, enable their water amount sliders (seperate to the plant info sliders)
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
            // If watering mode is enabled, set it to false, reset the cursor and disable all of the plot water amount sliders
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

    // Function called when the cursor enters a garden plot
    public void WaterEnter (GameObject plot)
    {
        if (plantInfo.gameObject.activeSelf == false)
        {
            // If the plant info window is disabled, set the selected plot to the given plot and set isHovering to true
            selectedPlot = plot.GetComponent<GardenPlotScript>();
            if (selectedPlot.plotState != 0)
            {
                isHovering = true;
            }
        }
    }

    // Called when the cursor exits a plot, disables the hovering bool
    public void WaterExit ()
    {
        isHovering = false;
    }

    // Called when clicking the more info button in the plant info window
    public void MoreInfo ()
    {
        // Sets the more info title text to be equal to the plant type and enables the more info window
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

    // Called when clicking the weeds slider to activate the weed pulling minigame
    public void EngageMinigame()
    {
        Instantiate(weedMinigame, gameObject.transform);
        if (isWatering)
        {
            OnWaterClick();
        }
    }
}
