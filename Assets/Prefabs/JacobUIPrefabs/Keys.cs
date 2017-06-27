using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour {
	public static Keys instance;

	//Store all info as a string
	public string usernameStored = "_usernameStored";
	public string passwordStored = "_passwordStored";
	public string nameStored = "_nameStored";
	public string ageStored = "_AgeStored";
	public string isMale = "_isMale";

	public string playerGrade = "_playerGrade";

	public void Start()
	{
		instance = this;

		//Make each of the variables null
		if(!PlayerPrefs.HasKey(usernameStored))
		{
			PlayerPrefs.SetString(usernameStored, null);
		}
		if(!PlayerPrefs.HasKey(passwordStored))
		{
			PlayerPrefs.SetString(usernameStored, null);
		}
		if(!PlayerPrefs.HasKey(nameStored))
		{
			PlayerPrefs.SetString(nameStored, null);
		}
		if(!PlayerPrefs.HasKey(ageStored))
		{
			PlayerPrefs.SetInt(ageStored, 0);
		}
		if(!PlayerPrefs.HasKey(isMale))
		{
			PlayerPrefs.SetInt (isMale, 0);
		}
		if(!PlayerPrefs.HasKey(playerGrade))
		{
			PlayerPrefs.SetInt(playerGrade, 0);
		}
	}
}
