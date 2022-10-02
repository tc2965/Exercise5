using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Door : MonoBehaviour
{
    public void OnTriggerEnter(Collider other) {
        print("hit something");
        if (other.CompareTag("Player") && PublicVars.keysCollected > 0) {
            print("hit player");
            gameObject.SetActive(false);
            Destroy(gameObject);
            PublicVars.keysCollected--;
            
        }
    }
}
