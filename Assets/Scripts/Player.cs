using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent _agent;
    Camera main_cam;

    public bool canShoot = true;
    public bool canThrowBomb = true;

    public GameObject bulletPrefab;
    int bulletForce = 500;
    float bulletYHeight = 0;

    public GameObject bombPrefab;
    int bombThrow = 750;
    float bombSpawnDist = 1;

    LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        main_cam = Camera.main;

        // get level manager
        GameObject levelManagerObj = GameObject.FindGameObjectWithTag("LevelManager");
        if (levelManagerObj != null) {
            levelManager = levelManagerObj.GetComponent<LevelManager>();
        } else {
            Debug.Log("LevelManager is null");
        }
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

                Vector3 playerDir = transform.forward;
                playerDir.y = bulletYHeight;

                GameObject newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
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
    }

    private void OnTriggerEnter(Collider other)
    {
        print("hit something");
        if (other.CompareTag("Key")) {
            if (levelManager != null) {
                levelManager.addKey();
            }

            Destroy(other.gameObject);
        }
    }
}
