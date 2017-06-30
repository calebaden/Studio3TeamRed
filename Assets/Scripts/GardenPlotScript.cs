using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GardenPlotScript : MonoBehaviour
{
    public int plotState;       // Integer storing the state of the plot; 0 = Empty, 1 = Seed, 2 = Plant
    public string plantType;    // String storing the plants type/title

    [SerializeField]
    private Image seed;         // Image of a seed used for the plots
    [SerializeField]
    private Image plant;        // Image of a plant used for the plots

    public Slider plotWater;    // Slider that displays the plots water amount when in watering mode

    public Sprite sunflower;    // Sprite for sunflower plants
    public Sprite carrot;       // Spirte for carrot plants

    public float growthAmount;  // The current amount that the plant has grown, min = just planted, max = fully grown
    public float growthRate;    // The rate at which the plants growth amount increases

    public float waterAmount;   // The current amount of water the plant has
    public float waterIncrease; // The rate that the water amount increases when watering
    public float waterDecrease; // The rate that the water amount decreases over time
    public float maxWater;      // The maximum amount of water a plant can have

    // Use this for initialization
    void Start ()
    {
        // Disable all of the closed windows on start
        seed.gameObject.SetActive(false);
        plant.gameObject.SetActive(false);
        plotWater.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        // If the plot has a seed in it, increase the growth amount and clamp it between 0 and 1
		if (plotState == 1)
        {
            growthAmount += growthRate * Time.deltaTime;
            growthAmount = Mathf.Clamp01(growthAmount);
            // If the plant reaches the maximum growth amount, call the finish growing function
            if (growthAmount >= 1)
            {
                FinishGrowing();
            }
        }
        if (plotState != 0)
        {
            // If the plant has water, decrease it over time, if not then call the kill funtion
            if (waterAmount > 0)
            {
                waterAmount -= waterDecrease * Time.deltaTime;
            }
            else
            {
                KillPlant();
            }
            // If the plot water slider is active, set its value to the plot water amount
            if (plotWater != null)
            {
                plotWater.value = waterAmount;
            }
        }
	}

    // Function called when planting a seed
    public void UpdatePlant (int seedType)
    {
        // Change the plot state from empty to seed, set the plat type based on the seed type and activate the seed sprite gameObject
        plotState = 1;
        if (seedType == 0)
        {
            plantType = "Sunflower";
        }
        else if (seedType == 1)
        {
            plantType = "Carrot";
        }

        seed.gameObject.SetActive(true);
    }

    // Function called when a plant reaches maximum growth amount
    public void FinishGrowing ()
    {
        // Change the plot state from seed to grown plant, disable the seed sprite gameObject
        plotState = 2;
        seed.gameObject.SetActive(false);
        // Change the plant sprite depending on the plat type, enable the plant sprite gameObject
        if (plantType == "Sunflower")
        {
            plant.sprite = sunflower;
        }
        else if (plantType == "Carrot")
        {
            plant.sprite = carrot;
        }
        plant.gameObject.SetActive(true);
    }

    // Function called when the plot water amount reaches 0
    public void KillPlant ()
    {
        // Checks what plant sprite gameObject is active and disable them
        if (plant.gameObject.activeSelf == true)
        {
            plant.gameObject.SetActive(false);
        }
        if (seed.gameObject.activeSelf == true)
        {
            seed.gameObject.SetActive(false);
        }
        // Changes the plot state to empty and reset variables to default
        plotState = 0;
        plantType = null;
        growthAmount = 0;
        waterAmount = 0.1f;
    }

    // Function called when holding down click on a plant while in watering mode
    public void WaterPlant ()
    {
        // Increases the plot water amount over time and clamps it between 0 and 1
        waterAmount += waterIncrease * Time.deltaTime;
        waterAmount = Mathf.Clamp01(waterAmount);
    }
}
