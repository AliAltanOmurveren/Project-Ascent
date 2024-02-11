using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeholder : MonoBehaviour
{
    Camera mainCamera;
    MainCameraFrustum frustum;
    Collider col;

    void Start()
    {
        mainCamera = Camera.main;

        frustum = mainCamera.GetComponent<MainCameraFrustum>();

        col = GetComponent<Collider>();
    }


    void Update()
    {
        if(GeometryUtility.TestPlanesAABB(frustum.frustumPlanes, col.bounds)){
            Debug.Log(gameObject.name);
        }
    }
}
