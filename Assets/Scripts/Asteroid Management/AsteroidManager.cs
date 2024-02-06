using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public List<GameObject> asteroidPrefabs;
    public GameObject ship;
    int asteroidCount;
    public float asteroidSphereRadius = 300;

    void Start()
    {
        asteroidCount = 500;

        for(int i = 0; i < asteroidCount; i++){
            int randomIndex = Random.Range(0, asteroidPrefabs.Count);

            GameObject asteroid = Instantiate(asteroidPrefabs[randomIndex], GetRandomPosition(ship, 5, asteroidSphereRadius), Quaternion.identity); 
            
            asteroid.transform.SetParent(transform);

            asteroid.GetComponent<Asteroid>().ship = ship;
        }
    }


    void Update()
    {
        
    }

    public Vector3 GetRandomPosition(GameObject ship, float offset, float max){
        float x = Random.Range(ship.transform.position.x - offset - max, ship.transform.position.x + offset + max);
        float y = Random.Range(ship.transform.position.y - offset - max, ship.transform.position.y + offset + max);
        float z = Random.Range(ship.transform.position.z - offset - max, ship.transform.position.z + offset + max);

        return new Vector3(x, y, z);
    }
}
