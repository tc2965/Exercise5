using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifespan : MonoBehaviour
{
    public float lifeTime = 1;
    
    public string[] tags;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("object collided with something");
        
        // remove bullet when it collides with non-player and non-key object
        if (!other.CompareTag("Key")) {
            Destroy(gameObject);
        }
    }
}
