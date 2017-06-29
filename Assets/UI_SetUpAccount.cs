using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SetUpAccount : MonoBehaviour {
	int ageNumber;
	int gradeNumber;
	public Text nameEntry;
	public Text ageEntry;
	public Text gradeEntry;
	public Text usernameEntry;
	public Text passwordEntry;
	public int genderEntry;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick()
	{
		// Check if any of the text entries are false
		if(nameEntry.text != null && 
		gradeEntry.text != null && 
		usernameEntry.text != null && 
		genderEntry == 0 && 
		passwordEntry.text != null)
		{
			// Check if the key exists, then update it
			if(!PlayerPrefs.HasKey(Keys.instance.usernameStored))
			{
				PlayerPrefs.SetString(Keys.instance.usernameStored, usernameEntry.text);
			}
			else
				Debug.Log("Missing Username Data");
			if(!PlayerPrefs.HasKey(Keys.instance.passwordStored))
			{
				PlayerPrefs.SetString(Keys.instance.usernameStored, passwordEntry.text);
			}
			else
				Debug.Log("Missing Password Data");
			if(!PlayerPrefs.HasKey(Keys.instance.nameStored))
			{
				PlayerPrefs.SetString(Keys.instance.nameStored, nameEntry.text);
			}
			else
				Debug.Log("Missing Name Data");
			if(!PlayerPrefs.HasKey(Keys.instance.ageStored))
			{
				int.TryParse(ageEntry.text, out ageNumber);

				PlayerPrefs.SetInt(Keys.instance.ageStored, ageNumber);
			}
			else
				Debug.Log("Missing Age Data");
			if(!PlayerPrefs.HasKey(Keys.instance.playerGrade))
			{
				int.TryParse(gradeEntry.text, out gradeNumber);

				PlayerPrefs.SetInt(Keys.instance.playerGrade, gradeNumber);
			}
			else
				Debug.Log("Missing Grade Data");
			Debug.Log("Account Creation successful! Username: " + PlayerPrefs.GetString(Keys.instance.usernameStored) + " Password: " + PlayerPrefs.GetString(Keys.instance.passwordStored) + " Age: " + PlayerPrefs.GetInt(Keys.instance.ageStored) + " Name: " + PlayerPrefs.GetInt(Keys.instance.nameStored) + " Grade: " + PlayerPrefs.GetInt(Keys.instance.playerGrade) + " Gender: " + PlayerPrefs.GetInt(Keys.instance.isMale));
		}
		else
		{
			// If the script can't find/access the data in an Entry, find out which one is broken
			if(nameEntry.text == null) 
				Debug.Log(nameEntry.name + " is null");
			if(gradeEntry.text != null) 
				Debug.Log(gradeEntry.name + " is null");
			if(usernameEntry.text != null) 
				Debug.Log(usernameEntry.name + " is null");
			if(genderEntry == 0)
				Debug.Log("genderEntry is null");
			if(passwordEntry.text != null)
				Debug.Log(passwordEntry.name + " is null");
		}
	}
}
