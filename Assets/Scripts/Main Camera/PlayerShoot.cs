using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    
    public Transform laserSpawnPosition;
    public GameObject playerLaser;

    public TextMeshProUGUI remainingLaserText;

    int remainingLaser;

    const int INITIAL_LASER_COUNT = 100;

    public Image crosshairUI;

    public Sprite laserCrosshairSprite;
    public Sprite rocketCrosshairSprite;

    void Start()
    {
        remainingLaser = INITIAL_LASER_COUNT;

        UpdateRemainingLaserUI();

        crosshairUI.sprite = laserCrosshairSprite;
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            crosshairUI.sprite = rocketCrosshairSprite;
        }

        if(Input.GetMouseButtonUp(1)){
            crosshairUI.sprite = laserCrosshairSprite;
        }

        if(Input.GetMouseButton(1)){
            // rocket

        }else{
            // laser

            if(Input.GetMouseButtonDown(0)){
                if(remainingLaser > 0){
                    remainingLaser -= 1;

                    UpdateRemainingLaserUI();

                    GameObject laser = Instantiate(playerLaser, laserSpawnPosition.position, Quaternion.LookRotation(transform.forward, transform.up));
                    laser.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
                }
            }
        }
    }

    void UpdateRemainingLaserUI(){
        remainingLaserText.text = remainingLaser.ToString();
    }
}
