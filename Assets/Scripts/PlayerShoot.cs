using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    
    public Transform laserSpawnPosition;
    public GameObject playerLaser;

    public TextMeshProUGUI remainingLaserText;

    int remainingLaser;

    const int INITIAL_LASER_COUNT = 100;

    void Start()
    {
        remainingLaser = INITIAL_LASER_COUNT;

        UpdateRemainingLaserUI();
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if(remainingLaser > 0){
                remainingLaser -= 1;

                UpdateRemainingLaserUI();

                GameObject laser = Instantiate(playerLaser, laserSpawnPosition.position, Quaternion.LookRotation(transform.forward, transform.up));
                laser.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
            }
        }
    }

    void UpdateRemainingLaserUI(){
        remainingLaserText.text = remainingLaser.ToString();
    }
}
