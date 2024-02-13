using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITarget
{
    float DistanceFromCamera();
    bool IsInCameraView();
    GameObject GetGameObject();
}
