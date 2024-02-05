using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour, IHealth
{
    private float _maxHp;
    private float _currentHp;

    public float MaxHp { get => _maxHp; set => _maxHp = value; }
    public float CurrentHp { get => _currentHp; set => _currentHp = value; }

    Rigidbody rb;

    public Image healthBar;

    void Start()
    {
        MaxHp = 100;
        CurrentHp = MaxHp;

        rb = gameObject.GetComponent<Rigidbody>();
    }


    void Update()
    {
        
    }

    public void DecreaseHp(float amount)
    {
        CurrentHp -= amount;

        if(CurrentHp <= 0){
            CurrentHp = 0;

            OnDeath();
        }

        healthBar.rectTransform.localScale = new Vector3(CurrentHp / MaxHp, 1, 1);
    }

    public void IncreaseHp(float amount)
    {
        CurrentHp += amount;

        if(CurrentHp > MaxHp){
            CurrentHp = MaxHp;
        }

        healthBar.rectTransform.localScale = new Vector3(CurrentHp / MaxHp, 1, 1);
    }

    public void OnDeath()
    {
        Debug.Log("Death");
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Asteroid")){
            DecreaseHp(10);

            Debug.Log("Hit");
        }
    }
}
