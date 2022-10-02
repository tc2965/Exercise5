using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent _agent;
    Camera main_cam;

    public GameObject bulletPrefab;
    int bulletForce = 500;

    public GameObject bombPrefab;
    int bombThrow = 750;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        main_cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
        
            if (Physics.Raycast(main_cam.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
                _agent.SetDestination(hit.point);
            }
        }
        else if(Input.GetMouseButtonDown(1)) {
            RaycastHit hit;
            if (Physics.Raycast(main_cam.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
                transform.LookAt(hit.point);
                GameObject newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce);
            }

        }
        else if(Input.GetKeyDown("space")) {
            GameObject newBomb = Instantiate(bombPrefab, transform.position, transform.rotation);
            newBomb.GetComponent<Rigidbody>().AddForce(transform.forward * bombThrow);
        }
    }
}
