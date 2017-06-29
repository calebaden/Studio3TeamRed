using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_AppleAccountCreationInfo : MonoBehaviour
{

    public enum TextEntryState
    {
        name,
        age,
        grade,
        username,
        password
    }

    public TextEntryState textEntryState;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnEditComplete()
    {

        /*switch(textEntryState)
            {
            case TextEntryState.name:
                {
                    Debug.Log("Name edit is complete");
                    UI_SetUpAccount.instance.nameEntry = GetComponent<InputField>().text;
                    break;
                }
            case TextEntryState.age:
                {
                    Debug.Log("Age edit is complete");
                    UI_SetUpAccount.instance.ageEntry = GetComponent<InputField>().text;
                    break;
                }
            case TextEntryState.grade:
                {
                    Debug.Log("Grade edit is complete");
                    UI_SetUpAccount.instance.gradeEntry = GetComponent<InputField>().text;
                    break;
                }
            case TextEntryState.username:
                {
                    Debug.Log("username edit is complete");
                    UI_SetUpAccount.instance.usernameEntry = GetComponent<InputField>().text;
                    break;
                }
            case TextEntryState.password:
                {
                    Debug.Log("password edit is complete");
                    UI_SetUpAccount.instance.passwordEntry = GetComponent<InputField>().text;
                    break;
                }
        }

    }*/
    }
}
