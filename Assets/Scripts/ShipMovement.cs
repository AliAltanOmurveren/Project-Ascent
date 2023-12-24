using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    float movementSensitivity = 10;
    float maxSpeed = 10;
    float speedDamping = 0.5f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        
    }

    private void FixedUpdate() {
        if(Input.GetKey(KeyCode.W)){
            rb.AddForce(transform.forward * movementSensitivity, ForceMode.Impulse);
        }

        if(Input.GetKey(KeyCode.S)){
            rb.AddForce(-transform.forward * movementSensitivity, ForceMode.Impulse);
        }

        if(Input.GetKey(KeyCode.A)){
            rb.AddForce(-transform.right * movementSensitivity, ForceMode.Impulse);
        }

        if(Input.GetKey(KeyCode.D)){
            rb.AddForce(transform.right * movementSensitivity, ForceMode.Impulse);
        }

        if(Input.GetKey(KeyCode.LeftControl)){
            rb.AddForce(-transform.up * movementSensitivity, ForceMode.Impulse);
        }

        if(Input.GetKey(KeyCode.Space)){
            rb.AddForce(transform.up * movementSensitivity, ForceMode.Impulse);
        }

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        if(!Input.anyKey){
            rb.velocity *= speedDamping;
        }
    }
}
