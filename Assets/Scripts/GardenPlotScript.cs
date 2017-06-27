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
}
