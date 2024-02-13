using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeholder : MonoBehaviour, ITarget
{
    Camera mainCamera;
    MainCameraFrustum frustum;
    Collider col;

    TargetsInView targetsInView;

    bool wasInView = false;

    void Start()
    {
        mainCamera = Camera.main;

        frustum = mainCamera.GetComponent<MainCameraFrustum>();
        targetsInView = mainCamera.GetComponent<TargetsInView>();

        col = GetComponent<Collider>();
    }


    void Update()
    {
        if(IsInCameraView()){
            targetsInView.targets.Add(this);
            wasInView = true;
        }else{
            if(wasInView){
                targetsInView.targets.Remove(this);
                wasInView = false;
            }
        }
    }

    public float DistanceFromCamera(){
        return Vector3.Distance(transform.position, mainCamera.transform.position);
    }

    public bool IsInCameraView(){
        if(GeometryUtility.TestPlanesAABB(frustum.frustumPlanes, col.bounds)){
            return true;
        }

        return false;
    }

    public GameObject GetGameObject(){
        return gameObject;
    }
}
