using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionScript : MonoBehaviour
{
    [SerializeField]
    private int scrHeight;
    [SerializeField]
    private int scrWidth;

	// Use this for initialization
	void Start ()
    {
        Screen.SetResolution(scrWidth, scrHeight, false);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
