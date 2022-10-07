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

    public bool canShoot = true;
    public bool canThrowBomb = true;

    public GameObject bulletPrefab;
    int bulletForce = 500;
    float bulletSpawnDist = 1;
    float bulletYHeight = 0;

    public GameObject bombPrefab;
    int bombThrow = 750;
    float bombSpawnDist = 1;
    
    public float healthRemaining;


    private const float health = 100;
    private Image healthBarImage;
    LevelManager levelManager;
    DisplayPlayerDetails displayPlayerDetails;

    public AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        healthRemaining = 100;
        healthBarImage = GameObject.FindWithTag("HealthBar").GetComponent<Image>();
        _agent = GetComponent<NavMeshAgent>();
        main_cam = Camera.main;

        // get level manager
        GameObject levelManagerObj = GameObject.FindGameObjectWithTag("LevelManager");
        if (levelManagerObj != null) {
            levelManager = levelManagerObj.GetComponent<LevelManager>();
        } else {
            Debug.Log("LevelManager is null");
        }

        GameObject displayPlayerDetailsMaybe = GameObject.FindGameObjectWithTag("DisplayPlayerDetails");
        if (displayPlayerDetailsMaybe != null) {
            displayPlayerDetails = displayPlayerDetailsMaybe.GetComponent<DisplayPlayerDetails>();
        } else {
            Debug.Log("displayPlayerDetailsMaybe is null");
        }

        // get audio src
        audioSrc = GetComponent<AudioSource>();
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
        else if(Input.GetMouseButtonDown(1) && canShoot) {
            RaycastHit hit;
            if (Physics.Raycast(main_cam.ScreenPointToRay(Input.mousePosition), out hit, 150)) {
                transform.LookAt(hit.point);

                Vector3 playerPos = transform.position;
                Vector3 playerDir = transform.forward;

                GameObject newBullet = Instantiate(bulletPrefab, playerPos + playerDir * bulletSpawnDist, transform.rotation);

                playerDir.y = bulletYHeight;
                newBullet.GetComponent<Rigidbody>().AddForce(playerDir * bulletForce);
            }

        }
        // player throw bomb
        else if(Input.GetKeyDown("space") && canThrowBomb) {
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
            if (levelManager != null) {
                levelManager.addKey();
            }

            Destroy(other.gameObject);
        }
    }

    public void DamagePlayer(float damage = 10.0f) {
        healthRemaining -= damage;

        if (healthRemaining <= 0) {
            levelManager.ResetLevel();
        }
    }

    public void UpdateHealth() {
        healthBarImage.fillAmount = Mathf.Clamp(healthRemaining / health, 0, 1f);
    }
}
