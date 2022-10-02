using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform playerTrans;
    Vector3 offset;

    // option to allow camera rotation
    public bool allowRotate = true;
    float rotateSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - playerTrans.position;
    }

    void LateUpdate()
    {
        // rotate on right click
        if (allowRotate && Input.GetKey(KeyCode.R)) {
            Quaternion cameraTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotateSpeed, Vector3.up);
            offset = cameraTurnAngle * offset;
        }

        transform.position = playerTrans.position + offset;
        transform.LookAt(playerTrans);
    }
}
