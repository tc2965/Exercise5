using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorV2 : MonoBehaviour
{

    public int doorCode;
    
    public bool triggerDoor = false; // option for door to load new scene
    [SerializeField] private string nextLevel = "Level1"; // name of scene to load

    LevelManager levelManager;

    void Start() {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
    }

    public void OnTriggerEnter(Collider other) {
        Debug.Log("in trigger");
        
        if (other.gameObject.CompareTag("Player") && levelManager.accessDoor(doorCode)) {
            Debug.Log("hit player");
            
            if (triggerDoor) {
                SceneManager.LoadScene(nextLevel);
            }
            
            Destroy(gameObject);            
        }
    }
}
