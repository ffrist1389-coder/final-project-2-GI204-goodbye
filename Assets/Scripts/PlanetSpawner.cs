using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyBulletPrefab;

    public int spawnAmount = 3;
    public float spawnRadius = 2f;

    private bool hasSpawned = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasSpawned)
        {
            SpawnEnemies();
            hasSpawned = true;
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector2 pos = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

            GameObject enemy = Instantiate(enemyPrefab, pos, Quaternion.identity);

            // 🔥 ตั้งค่า bulletPrefab ให้แน่นอน
            EnemyShooter2D shooter = enemy.GetComponent<EnemyShooter2D>();

            if (shooter != null)
            {
                shooter.bulletPrefab = enemyBulletPrefab;
            }
            else
            {
                Debug.LogError("Enemy ไม่มี EnemyShooter2D!");
            }
        }
    }
}
