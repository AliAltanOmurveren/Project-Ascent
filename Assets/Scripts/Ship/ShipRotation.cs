using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRotation : MonoBehaviour
{
    public GameObject anchor;

    float sensitivity = 500;

    Rigidbody rb;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if(Input.GetAxis("Mouse Y") < 0){
            transform.rotation *= Quaternion.AngleAxis(sensitivity * Time.deltaTime * Mathf.Abs(Input.GetAxis("Mouse Y")), anchor.transform.right);
        }
       
        if(Input.GetAxis("Mouse Y") > 0){
            transform.rotation *= Quaternion.AngleAxis(-sensitivity * Time.deltaTime * Mathf.Abs(Input.GetAxis("Mouse Y")), anchor.transform.right);
        } 
 
        if(Input.GetAxis("Mouse X") > 0){
            transform.rotation *= Quaternion.AngleAxis(sensitivity * Time.deltaTime * Mathf.Abs(Input.GetAxis("Mouse X")), Vector3.up);
        }

        if(Input.GetAxis("Mouse X") < 0){
            transform.rotation *= Quaternion.AngleAxis(-sensitivity * Time.deltaTime * Mathf.Abs(Input.GetAxis("Mouse X")), Vector3.up);
        }

        if(Input.GetKey(KeyCode.Q)){
            transform.Rotate(transform.position + (transform.forward - transform.position), sensitivity * Time.deltaTime, Space.World);
        }

        if(Input.GetKey(KeyCode.E)){
            transform.Rotate(transform.position + (transform.forward - transform.position), -sensitivity * Time.deltaTime, Space.World);
        }
    }
}
