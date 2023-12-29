using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public List<GameObject> asteroidPrefabs;
    public GameObject ship;
    int asteroidCount;

    void Start()
    {
        asteroidCount = 500;

        for(int i = 0; i < asteroidCount; i++){
            int randomIndex = Random.Range(0, asteroidPrefabs.Count);

            Instantiate(asteroidPrefabs[randomIndex], getRandomPosition(ship, 5, 300), Quaternion.identity); 
        }
    }


    void Update()
    {
        
    }

    Vector3 getRandomPosition(GameObject ship, float offset, float max){
        float x = Random.Range(ship.transform.position.x - offset - max, ship.transform.position.x + offset + max);
        float y = Random.Range(ship.transform.position.y - offset - max, ship.transform.position.y + offset + max);
        float z = Random.Range(ship.transform.position.z - offset - max, ship.transform.position.z + offset + max);

        return new Vector3(x, y, z);
    }
}
