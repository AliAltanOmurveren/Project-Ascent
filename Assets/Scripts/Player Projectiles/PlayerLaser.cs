using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    float force = 2;
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
        if(other.gameObject.tag != "PlayerLaser"){
            Destroy(gameObject);
        }
    }
}
