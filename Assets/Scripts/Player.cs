using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    NavMeshAgent _agent;
    Camera main_cam;

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
    }
}
