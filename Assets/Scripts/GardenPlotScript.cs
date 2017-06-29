using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GardenPlotScript : MonoBehaviour
{
    // 0 = Empty, 1 = Seed, 2 = Plant
    public int plotState;
    public string plantType;

    [SerializeField]
    private Image seed;
    [SerializeField]
    private Image plant;

    public Slider plotWater;

    public Sprite sunflower;
    public Sprite carrot;

    public float growthAmount;
    public float growthRate;

    public float waterAmount;
    public float waterIncrease;
    public float waterDecrease;
    public float maxWater;

    // Use this for initialization
    void Start ()
    {
        seed.gameObject.SetActive(false);
        plant.gameObject.SetActive(false);
        plotWater.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (plotState == 1)
        {
            growthAmount += growthRate * Time.deltaTime;
            growthAmount = Mathf.Clamp01(growthAmount);
            if (growthAmount >= 1)
            {
                FinishGrowing();
            }
        }
        if (plotState != 0)
        {
            if (waterAmount > 0)
            {
                waterAmount -= waterDecrease * Time.deltaTime;
            }
            else
            {
                KillPlant();
            }

            if (plotWater != null)
            {
                plotWater.value = waterAmount;
            }
        }
	}

    public void UpdatePlant (int seedType)
    {
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

    public void FinishGrowing ()
    {
        plotState = 2;
        seed.gameObject.SetActive(false);
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

    public void KillPlant ()
    {
        if (plant.gameObject.activeSelf == true)
        {
            plant.gameObject.SetActive(false);
        }
        if (seed.gameObject.activeSelf == true)
        {
            seed.gameObject.SetActive(false);
        }
        plotState = 0;
        plantType = null;
        growthAmount = 0;
        waterAmount = 0.1f;
    }

    public void WaterPlant ()
    {
        waterAmount += waterIncrease * Time.deltaTime;
    }
}
