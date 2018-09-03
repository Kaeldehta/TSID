using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{

    [SerializeField]
    private float spawnRadius = 100;

    [SerializeField]
    private float gapBetweenLayers = 10f;

    [SerializeField]
    private List<GameObject> asteroidPrefabList;

    [SerializeField]
    private int numberOfAsteroids = 20;
    
    [SerializeField]
    private int numberOfLayers = 3;

    [SerializeField]
    private float distanceFromDefaultLayer = 10f;

    void Start()
    {
        for (int i = 0; i < numberOfAsteroids; i++)
        {
            float rX = Random.Range(transform.position.x - spawnRadius, transform.position.x + spawnRadius);
            float rY = Random.Range(transform.position.y - spawnRadius, transform.position.y + spawnRadius);
            float rZ = Random.Range(0, numberOfLayers);

            Vector2 upwardsDir = Random.insideUnitCircle;
            Quaternion spawnRotation = Quaternion.LookRotation(Vector3.forward, upwardsDir);
            Vector3 spawnPos = new Vector3(rX, rY, distanceFromDefaultLayer < 0 ? -rZ * gapBetweenLayers : rZ * gapBetweenLayers);
            SpawnAsteroid(spawnPos, spawnRotation);
        }

        transform.position = Vector3.zero;
        transform.position += Vector3.forward * distanceFromDefaultLayer;
    }
    
    void SpawnAsteroid(Vector3 position, Quaternion rotation)
    {
        int asteroid = Random.Range(0, asteroidPrefabList.Count);
        GameObject spawnedAsteroid = Instantiate(asteroidPrefabList[asteroid]);
        spawnedAsteroid.transform.position = position;
        spawnedAsteroid.transform.rotation = rotation;
        spawnedAsteroid.transform.parent = transform;
    }
}
