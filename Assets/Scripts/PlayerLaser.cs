using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    float force = 75;
    Rigidbody rb;
    float laserLifetime = 3;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * force, ForceMode.Impulse);

        StartCoroutine(Lifetime());
    }


    void Update()
    {
        
    }

    IEnumerator Lifetime() {
        yield return new WaitForSeconds(laserLifetime);

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other) {
        Destroy(gameObject);
    }
}
