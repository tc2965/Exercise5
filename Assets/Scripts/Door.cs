using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int doorCode;

    public void OnTriggerEnter(Collider other) {
        print("in trigger");
        
        if (other.gameObject.CompareTag("Player") && PublicVars.keysCollected[doorCode]) {
            print("hit player");
            if (doorCode + 1 == PublicVars.totalKeys){
                SceneManager.LoadScene("WinScene");
            }
            Destroy(gameObject);            
        }
    }
    
}
