using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    TextMeshProUGUI fpsCount;

    void Start()
    {
        fpsCount = GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        fpsCount.text = "FPS: " + Mathf.FloorToInt(1 / Time.unscaledDeltaTime);
    }
}
