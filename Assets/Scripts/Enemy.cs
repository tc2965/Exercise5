using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    GameObject player;
    Player playerScript;
    NavMeshAgent _agent;

    public float attackRadius = 20f;

    public float health = 100;

    public float atkInterval = 2.0f;
    Coroutine attacking;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<Player>();
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
            takeDamage();
        } else if (other.CompareTag("Player")) {
            attacking = StartCoroutine(AttackPlayer());
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Player exited");
            StopCoroutine(attacking);
        }
    }

    IEnumerator AttackPlayer() {
        while (true) {
            playerScript.DamagePlayer();
            playerScript.UpdateHealth();
            yield return new WaitForSeconds(atkInterval);
        }
    }


    public void takeDamage(float dmg = 10.0f) {
        health -= dmg;

        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
