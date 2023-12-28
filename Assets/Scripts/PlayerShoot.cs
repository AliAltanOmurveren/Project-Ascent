using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    
    public Transform laserSpawnPosition;
    public GameObject playerLaser;

    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            GameObject laser = Instantiate(playerLaser, laserSpawnPosition.position, Quaternion.LookRotation(transform.forward, transform.up));
            laser.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
        }
    }
}
