using UnityEngine;

public class HealthPickupSpawner : MonoBehaviour
{
    [Header("Pickup Settings")]
    public GameObject healthPickupPrefab;
    public float spawnInterval = 10f;
    public int maxPickups = 3;

    [Header("Map Bounds")]
    public float minX = -30f;
    public float maxX = 30f;
    public float minY = -20f;
    public float maxY = 20f;

    private float nextSpawnTime;

    void Update()
    {
        if (healthPickupPrefab == null)
            return;

        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnInterval;

            int currentPickups = GameObject.FindGameObjectsWithTag("HealthPickup").Length;

            if (currentPickups < maxPickups)
            {
                SpawnPickup();
            }
        }
    }

    void SpawnPickup()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Vector3 spawnPos = new Vector3(randomX, randomY, 0f);

        Instantiate(healthPickupPrefab, spawnPos, Quaternion.identity);
    }
}
