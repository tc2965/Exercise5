using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifespan : MonoBehaviour
{
    public float lifeTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("object collided with something");
        
        // remove bullet when it collides with non-player object
        if (!other.CompareTag("Player")) {
            Destroy(gameObject);
        }
    }
}
