using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GardenPlotScript : MonoBehaviour
{
    VirtualGardenScript vgScr;

    // 0 = Empty, 1 = Seed, 2 = Plant
    public int plotState;
    public string plantType;

    [SerializeField]
    private Image seed;
    [SerializeField]
    private Image plant;

    public Texture sunflower;
    public Texture carrot;

    public float growthAmount;
    public float growthRate;

    // Use this for initialization
    void Start ()
    {
        vgScr = GameObject.FindGameObjectWithTag("VirtualGarden").GetComponent<VirtualGardenScript>();
        seed.gameObject.SetActive(false);
        plant.gameObject.SetActive(false);
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
            
        }
        else if (plantType == "Carrot")
        {

        }
        plant.gameObject.SetActive(true);
    }
}
