using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockTrapDoor : MonoBehaviour
{
    public GameObject trapDoor; 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trapDoor.SetActive(false);
        }
    }
}
