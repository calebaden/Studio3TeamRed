using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchScript : MonoBehaviour {

    public GameObject MinigameController;

    // Use this for initialization
    void Start()
    {
        MinigameController = GameObject.Find("MinigameManager");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PullWeed()
    {
        Debug.Log("Pull weed?");
        MinigameController.gameObject.GetComponent<MinigameManager>().objectivesCompleted += 1;
        Destroy(gameObject);
    }
}
