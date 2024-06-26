using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;      // Prefab of the enemy to spawn
    public float spawnInterval = 1f;    // Interval between enemy spawns
    private float spawnTimer;           // Timer to track when to spawn the next enemy
    
    void Start()
    {
        spawnTimer = 0f;
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        // Optionally, you can add additional logic here for enemy initialization or AI setup.
    }
}
