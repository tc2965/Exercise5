using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGun : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        Debug.Log("Gun collided with something");

        if (other.CompareTag("Player")) {
            Debug.Log("Gun collided with player");

            Player player = other.GetComponent<Player>();
            player.canShoot = true;
        }

        Destroy(gameObject);
    } 
}
