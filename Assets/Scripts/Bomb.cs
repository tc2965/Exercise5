using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float delay = 3f;
    public float bigRadius = 5f;
    public float smallRadius = 2f;
    public float force = 50f;

    public GameObject explosionEffect;

    float countdown;
    bool hasExploded = false;
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded) {
            Explode();
            hasExploded = true;
        }
    }

    void Explode() {
        // show effect
        Instantiate(explosionEffect, transform.position, transform.rotation);

        // get nearby objects
        Collider[] willMoveColliders = Physics.OverlapSphere(transform.position, bigRadius);
        Collider[] willDieColliders = Physics.OverlapSphere(transform.position, smallRadius);

        foreach (Collider nearbyObject in willDieColliders) {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null && nearbyObject.CompareTag("Destructable")) {
                Destroy(nearbyObject.gameObject);
            }
        }

        //move nearby objects that aren't static (I THINK)
        foreach (Collider nearbyObject in willMoveColliders) {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null && nearbyObject.CompareTag("Destructable")) {
                rb.AddExplosionForce(force, transform.position, bigRadius);
            }
        }
    }
}
