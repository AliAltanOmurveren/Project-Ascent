using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class Asteroid : MonoBehaviour, IHealth
{

    public GameObject ship;
    Rigidbody rb;
    float moveForce = 200;
    float asteroidSphereRadius;

    private float _maxHp;
    private float _currentHp;

    public float MaxHp { get => _maxHp; set => _maxHp = value; }
    public float CurrentHp { get => _currentHp; set => _currentHp = value; }

    private AsteroidManager asteroidManager;

    public ParticleSystem explosionPrefab;
    
    void Start()
    {
        asteroidManager = transform.parent.GetComponent<AsteroidManager>();

        transform.rotation = Random.rotation;

        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * moveForce, ForceMode.Impulse);

        asteroidSphereRadius = asteroidManager.asteroidSphereRadius;

        int randomHp = Random.Range(1, 4);

        MaxHp = randomHp;
        CurrentHp = MaxHp;
    }


    void Update()
    {
        transform.Rotate(new Vector3(30 * Time.deltaTime, 0, 0));

        if((transform.position - ship.transform.position).magnitude > asteroidSphereRadius){
            transform.position = ship.transform.position + (ship.transform.position - transform.position);
        }
    }

    public void DecreaseHp(float amount) {
        CurrentHp -= amount;

        if(CurrentHp <= 0){
            CurrentHp = 0;

            OnDeath();
        }
    }

    public void IncreaseHp(float amount) {

    }

    public void OnDeath() {
        ParticleSystem explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        explosion.Play();

        transform.position = asteroidManager.GetRandomPosition(asteroidManager.ship, 5, asteroidManager.asteroidSphereRadius);

        CurrentHp = MaxHp;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("PlayerLaser")){
            DecreaseHp(1);
        }
    }
}
