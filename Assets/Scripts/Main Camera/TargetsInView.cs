using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetsInView : MonoBehaviour
{
    public HashSet<ITarget> targets;

    void Awake()
    {
        targets = new HashSet<ITarget>();
    }


    void Update()
    {
        
    }

    public GameObject GetClosestTarget(){
        float closestDistance = 99999999;
        
        GameObject closestTarget = null;

        foreach(ITarget target in targets){
            float distanceFromCamera = Vector3.Distance(transform.position, target.GetGameObject().transform.position);

            if(distanceFromCamera < closestDistance){
                closestTarget = target.GetGameObject();
                closestDistance = distanceFromCamera;
            }
        }

        return closestTarget;
    }
}
