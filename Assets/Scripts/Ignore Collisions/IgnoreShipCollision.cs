using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreShipCollision : MonoBehaviour
{
    GameObject ship;

    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("ShipIgnore");
        Physics.IgnoreCollision(GetComponent<Collider>(), ship.GetComponent<Collider>());
    }


    void Update()
    {
        
    }
}
