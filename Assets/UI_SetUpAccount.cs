using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SetUpAccount : MonoBehaviour {
	public Text nameEntry;
	public Text ageEntry;

	int ageNumber;

	int gradeNumber;
	public Text gradeEntry;
	public int genderEntry;
	public Text usernameEntry;
	public Text passwordEntry;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick()
	{
		if(nameEntry.text != null && 
		gradeEntry.text != null && 
		usernameEntry.text != null && 
		genderEntry > 0 && 
		passwordEntry.text != null)
		{
			if(!PlayerPrefs.HasKey(Keys.instance.usernameStored))
			{
				PlayerPrefs.SetString(Keys.instance.usernameStored, usernameEntry.text);
			}
			if(!PlayerPrefs.HasKey(Keys.instance.passwordStored))
			{
				PlayerPrefs.SetString(Keys.instance.usernameStored, passwordEntry.text);
			}
			if(!PlayerPrefs.HasKey(Keys.instance.nameStored))
			{
				PlayerPrefs.SetString(Keys.instance.nameStored, nameEntry.text);
			}
			if(!PlayerPrefs.HasKey(Keys.instance.ageStored))
			{
				int.TryParse(ageEntry.text, out ageNumber);

				PlayerPrefs.SetInt(Keys.instance.ageStored, ageNumber);
			}
			if(!PlayerPrefs.HasKey(Keys.instance.playerGrade))
			{
				int.TryParse(gradeEntry.text, out gradeNumber);

				PlayerPrefs.SetInt(Keys.instance.playerGrade, gradeNumber);
			}
		}
		else
		{
			Debug.Log("Some input is missing!");
		}
	}
}
