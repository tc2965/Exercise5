using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    NavMeshAgent _agent;
    Camera main_cam;

    public GameObject bulletPrefab;
    private Image healthBarImage;
    int bulletForce = 500;

    public GameObject bombPrefab;
    int bombThrow = 750;
    float bombSpawnDist = 1;

    private const float health = 100;
    public float healthRemaining;

    // Start is called before the first frame update
    void Start()
    {
        healthRemaining = 100;
        healthBarImage = GameObject.FindWithTag("HealthBar").GetComponent<Image>();
        _agent = GetComponent<NavMeshAgent>();
        main_cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // player move
        if(Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
        
            if (Physics.Raycast(main_cam.ScreenPointToRay(Input.mousePosition), out hit, 150)) {
                _agent.SetDestination(hit.point);
            }
        }
        // player shoot bullet
        else if(Input.GetMouseButtonDown(1)) {
            RaycastHit hit;
            if (Physics.Raycast(main_cam.ScreenPointToRay(Input.mousePosition), out hit, 150)) {
                transform.LookAt(hit.point);
                GameObject newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce);
            }

        }
        // player throw bomb
        else if(Input.GetKeyDown("space")) {
            RaycastHit hit;

            if (Physics.Raycast(main_cam.ScreenPointToRay(Input.mousePosition), out hit, 150)) {
                transform.LookAt(hit.point);

                Vector3 playerPos = transform.position;
                Vector3 playerDir = transform.forward;

                GameObject newBomb = Instantiate(bombPrefab, playerPos + playerDir * bombSpawnDist, transform.rotation);
                newBomb.GetComponent<Rigidbody>().AddForce(playerDir * bombThrow);
            }
        }

        UpdateHealth();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key")) {
            PublicVars.keysCollected[PublicVars.currKeys++] = true;
            Destroy(other.gameObject);
        }
    }

    public void DamagePlayer(float damage = 10.0f) {
        healthRemaining -= damage;
    }

    public void UpdateHealth() {
        healthBarImage.fillAmount = Mathf.Clamp(healthRemaining / health, 0, 1f);
    }
}
