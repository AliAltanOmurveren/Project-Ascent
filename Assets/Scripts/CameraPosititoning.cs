using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosititoning : MonoBehaviour
{

    public GameObject ship;
    Vector3[] shipPositions;
    Quaternion[] shipRotations;
    Vector3 averagePosition;
    int index = 0;
    int smoothingFrameCount = 10;

    void Start()
    {
        shipPositions = new Vector3[smoothingFrameCount];
        shipRotations = new Quaternion[smoothingFrameCount];
    }


    void Update()
    {
        
    }

    private void FixedUpdate() {

        shipPositions[index] = ship.transform.position;
        shipRotations[index] = ship.transform.rotation;

        index += 1;
        index %= smoothingFrameCount;


        Vector3 sumOfPositions = Vector3.zero;

        for (int i = 0; i < smoothingFrameCount; i++){
            sumOfPositions += shipPositions[i];
        }

        averagePosition = sumOfPositions / smoothingFrameCount;

        transform.position = averagePosition;

        Quaternion averageRotation = Quaternion.identity;
        
        int amount = 0;

        foreach(Quaternion rot in shipRotations){
            amount++;

            averageRotation = Quaternion.Slerp(averageRotation, rot, 1.0f / amount);
        }

        transform.rotation = averageRotation;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 1);
        
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * 2);
    }
}
