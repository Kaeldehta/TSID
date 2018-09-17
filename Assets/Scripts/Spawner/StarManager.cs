using UnityEngine;

public class StarManager : MonoBehaviour
{
    [SerializeField]
    private GameObject starPrefab = null;

    [SerializeField]
    private int numberOfStars = 100;

    [SerializeField]
    private float spawnRadius = 100;

    [SerializeField]
    private float gapBetweenLayers = 10f;

    [SerializeField]
    private int numberOfLayers = 10;

    [SerializeField]
    private float backgroundDistance = 100f;

    void Start()
    {
        
        for (int i = 0; i < numberOfStars; i++)
        {
            float rX = Random.Range(transform.position.x - spawnRadius, transform.position.x + spawnRadius);
            float rY = Random.Range(transform.position.y - spawnRadius, transform.position.y + spawnRadius);
            float rZ = Random.Range(0, numberOfLayers);
            Color color = Random.ColorHSV();
            Vector3 spawnPos = new Vector3(rX, rY, rZ * gapBetweenLayers);
            SpawnStar(spawnPos, color);
        }

        transform.position = Vector3.zero;
        transform.position += Vector3.forward * backgroundDistance;
    }

    void SpawnStar(Vector3 position, Color color)
    {
        GameObject spawnedStar =  Instantiate(starPrefab);
        spawnedStar.transform.position = position;
        spawnedStar.transform.parent = transform;
        //spawnedStar.GetComponent<SpriteRenderer>().color = color;
        spawnedStar.GetComponent<Light>().color = color;
    }
}
