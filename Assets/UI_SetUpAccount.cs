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

    public static UI_SetUpAccount instance;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick()
	{
	    // Set the info
        // username
		PlayerPrefs.SetString(Keys.instance.usernameStored, usernameEntry.text);

        // password
		 PlayerPrefs.SetString(Keys.instance.passwordStored, passwordEntry.text);

        // Name
		PlayerPrefs.SetString(Keys.instance.nameStored, nameEntry.text);

        // Parse for age
		int.TryParse(ageEntry.text, out ageNumber);
		PlayerPrefs.SetInt(Keys.instance.ageStored, ageNumber);

        //Parse for grade
		int.TryParse(gradeEntry.text, out gradeNumber);
        PlayerPrefs.SetInt(Keys.instance.playerGrade, gradeNumber);

	    Debug.Log("Account Creation successful! Username: " + PlayerPrefs.GetString(Keys.instance.usernameStored) + " Password: " + PlayerPrefs.GetString(Keys.instance.passwordStored) + " Age: " + PlayerPrefs.GetInt(Keys.instance.ageStored) + " Name: " + PlayerPrefs.GetString(Keys.instance.nameStored) + " Grade: " + PlayerPrefs.GetInt(Keys.instance.playerGrade) + " Gender: " + PlayerPrefs.GetInt(Keys.instance.isMale));

        /*Debug.Log(nameEntry.text + " = " + nameEntry);
        Debug.Log(usernameEntry.text + " = " + usernameEntry);
        Debug.Log(passwordEntry.text + " = " + passwordEntry);
        Debug.Log(ageEntry.text + " = " + ageEntry);
        Debug.Log(gradeEntry.text + " = " + gradeEntry);
        Debug.Log("Gender is" + genderEntry);*/
    }
}
