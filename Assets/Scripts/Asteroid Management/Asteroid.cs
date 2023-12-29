using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    
    void Start()
    {
        transform.rotation = Random.rotation;
    }


    void Update()
    {
        transform.Rotate(new Vector3(30 * Time.deltaTime, 0, 0));
    }
}
