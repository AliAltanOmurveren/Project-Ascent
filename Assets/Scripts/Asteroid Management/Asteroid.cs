using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public GameObject ship;
    Rigidbody rb;
    float moveForce = 200;
    float asteroidSphereRadius;

    
    void Start()
    {
        transform.rotation = Random.rotation;
        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * moveForce, ForceMode.Impulse);

        asteroidSphereRadius = transform.parent.GetComponent<AsteroidManager>().asteroidSphereRadius;
    }


    void Update()
    {
        transform.Rotate(new Vector3(30 * Time.deltaTime, 0, 0));

        if((transform.position - ship.transform.position).magnitude > asteroidSphereRadius){
            transform.position = ship.transform.position + (ship.transform.position - transform.position);
        }
    }
}
