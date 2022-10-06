using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        Debug.Log("object collided with something");
        
        // remove bullet when it collides with non-player and non-key object
        if (!other.CompareTag("Key")) {
            Destroy(gameObject);
        }
    }
}
