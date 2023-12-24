using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosititoning : MonoBehaviour
{

    public GameObject ship;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void LateUpdate() {
        transform.position = ship.transform.position;
        transform.rotation = ship.transform.rotation;
    }
}
