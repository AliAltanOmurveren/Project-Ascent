using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipBoost : MonoBehaviour
{
    Rigidbody rb;
    float maxBoostDuration = 3.0f;
    float remainingBoost;
    float boostRechargeTime = 9.0f;
    public Image boostBar;

    public bool canBoost;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        remainingBoost = maxBoostDuration;
    }


    void Update()
    {
        if(rb.velocity.magnitude > 0 && Input.GetKey(KeyCode.LeftShift) && remainingBoost > 0){
            remainingBoost -= Time.deltaTime;

            boostBar.rectTransform.localScale = new Vector3(remainingBoost / maxBoostDuration, 1, 1);

            canBoost = true;
        }else{
            canBoost = false;
        }
        
        if(!Input.GetKey(KeyCode.LeftShift) && remainingBoost <= maxBoostDuration){
            remainingBoost += Time.deltaTime / boostRechargeTime * maxBoostDuration;

            boostBar.rectTransform.localScale = new Vector3(remainingBoost / maxBoostDuration, 1, 1);
        }
    }
}
