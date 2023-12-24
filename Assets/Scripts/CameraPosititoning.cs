using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosititoning : MonoBehaviour
{

    public GameObject ship;
    Vector3[] shipPositions;
    Vector3 averagePosition;
    int index = 0;
    int smoothingFrameCount = 10;

    void Start()
    {
        shipPositions = new Vector3[smoothingFrameCount];
    }


    void Update()
    {
        
    }

    private void LateUpdate() {

        shipPositions[index] = ship.transform.position;

        index += 1;
        index %= smoothingFrameCount;


        Vector3 sumOfPositions = Vector3.zero;

        for (int i = 0; i < smoothingFrameCount; i++){
            sumOfPositions += shipPositions[i];
        }

        averagePosition = sumOfPositions / smoothingFrameCount;

        transform.position = averagePosition;

        transform.rotation = ship.transform.rotation;
    }
}
