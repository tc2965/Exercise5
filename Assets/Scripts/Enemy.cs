using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    GameObject player;
    NavMeshAgent _agent;

    public float attackRadius = 20f;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(PlayerInRadius());
    }

    IEnumerator PlayerInRadius() {
        while (true) {
            Collider[] checkForPlayer = Physics.OverlapSphere(transform.position, attackRadius);
            foreach (Collider nearbyObject in checkForPlayer) {
                if (nearbyObject.gameObject == player) {
                    yield return StartCoroutine(LookForPlayer());
                }
            }
            yield return new WaitForSeconds(.5f);
        }
        
    }

    IEnumerator LookForPlayer() {
        while (true) {
            yield return new WaitForSeconds(.5f);
            _agent.SetDestination(player.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Bullet")) {
            Destroy(gameObject);
        }
    }
}
