using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_LoginLogic : MonoBehaviour {
	public Text usernameEntry;
	public Text passwordEntry;

    public GameObject loginErrorPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick()
	{
		//First, check if both text entries are full
		if(usernameEntry.text != null || passwordEntry.text != null)
		{
			//Compare the username and password with their entries in PlayerPrefs
			if(PlayerPrefs.HasKey(Keys.instance.usernameStored) && PlayerPrefs.HasKey(Keys.instance.passwordStored))
			{
				Debug.Log("username and password keys found!");
				if(PlayerPrefs.GetString(Keys.instance.usernameStored) == usernameEntry.text)
				{
					Debug.Log("Username checks out");
						
						// Check the password
						if(PlayerPrefs.GetString(Keys.instance.passwordStored) == passwordEntry.text)
						{
							Debug.Log("Password checks out");
							Login();
						}
						else
						{
                        loginErrorPanel.SetActive(true);
							Debug.Log("Password not recognised");
						}
				}
				else
				{
					Debug.Log("Username doesn't match the database!");
                    loginErrorPanel.SetActive(true);
                }
			}
			else
			{
				Debug.Log("username and password keys not found!");
                loginErrorPanel.SetActive(true);
            }
		}
		else
		{
			Debug.Log("Either Username or Password entries are empty!");
		}
	}

	public void Login()
	{
		Debug.Log("Logging the player in!");
	}
}
