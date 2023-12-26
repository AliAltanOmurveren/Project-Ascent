using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCameraCollision : MonoBehaviour
{
    
    void Start()
    {
        Physics.IgnoreCollision(Camera.main.GetComponent<Collider>(), GetComponent<Collider>());
    }


    void Update()
    {
        
    }
}
