﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{

    public float objectivesCompleted;
    public Slider progressBar;
    public Text progressText;
    public GameObject congratsMessage;
    public LeviScript leviScript;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        progressBar.value = objectivesCompleted;
        progressText.text = progressBar.value + "/5";

        if (objectivesCompleted == 5)
        {
            congratsMessage.gameObject.SetActive(true);
            leviScript.plantHasBeenCut = true;
        }
    }
}