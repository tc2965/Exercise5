using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBomb : MonoBehaviour
{
    AudioSource audioSrc;
    public AudioClip audioClip;

    void Start() {
        audioSrc = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Gun collided with something");

        if (other.CompareTag("Player")) {
            Debug.Log("Gun collided with player");

            Player player = other.GetComponent<Player>();
            player.canThrowBomb = true;

            if (audioSrc != null && audioClip != null) {
                audioSrc.PlayOneShot(audioClip);
            }
        }

        Destroy(gameObject);
    } 
}
