using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraFrustum : MonoBehaviour
{

    public Plane[] frustumPlanes;
    Camera mainCamera;

    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        frustumPlanes = GeometryUtility.CalculateFrustumPlanes(mainCamera);
    }
}
