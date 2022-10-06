using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayPlayerDetails : MonoBehaviour
{
    public TextMeshProUGUI displayName;
    public TextMeshProUGUI keys;
    LevelManager levelManager;
    PlayerDetails playerDetails;
    // Start is called before the first frame update
    void Start()
    {
        // get level manager
        GameObject levelManagerObj = GameObject.FindGameObjectWithTag("LevelManager");
        if (levelManagerObj != null) {
            levelManager = levelManagerObj.GetComponent<LevelManager>();
        } else {
            Debug.Log("LevelManager is null");
        }

        // get level manager
        GameObject playerDetailsMaybe = GameObject.FindGameObjectWithTag("PlayerDetails");
        if (playerDetailsMaybe != null) {
            playerDetails = playerDetailsMaybe.GetComponent<PlayerDetails>();
        } else {
            Debug.Log("PlayerDetails is null");
            displayName.text = "";
        }


        displayName.text = "Player: " + playerDetails.GetComponent<PlayerDetails>().getPlayerName();
        keys.text = "Keys Collected: " + levelManager.getKeysCollected().ToString() + "/" + levelManager.totalKeys().ToString();
    }

}
