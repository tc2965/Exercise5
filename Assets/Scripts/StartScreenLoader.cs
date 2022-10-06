using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartScreenLoader : MonoBehaviour
{
    public TMP_InputField nameField;
    public GameObject playerDetails;
    
    public void OnSubmit() 
    {
        if (!string.IsNullOrEmpty(nameField.text))
            {
                playerDetails.GetComponent<PlayerDetails>().setPlayerName(nameField.text);
            }
    }
}
