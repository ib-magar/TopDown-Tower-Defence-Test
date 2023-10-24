using UnityEngine;
    public class LevelManager : MonoBehaviour
    {

        public Wave[] waves;
        public GameObject enemyPrefab;
        //public Transform spawnPoint;
        public float timeBetweenWaves = 5f;
        public float timeBetweenSpawns = 1f;

        private int currentWaveIndex = 0;
        private int enemiesLeftToSpawn;
        private int enemiesAlive;

        private void Start()
        {
            StartNextWave();
        }

        private void StartNextWave()
        {
            if (currentWaveIndex < waves.Length)
            {
                Wave currentWave = waves[currentWaveIndex];
                enemiesLeftToSpawn = currentWave.enemyCount;
                enemiesAlive = currentWave.enemyCount;

                // Start spawning enemies for the current wave
                InvokeRepeating(nameof(SpawnEnemy), 0f, timeBetweenSpawns);
            }
            else
            {
                Debug.Log("All waves are complete!");
            }
        }

        private void SpawnEnemy()
        {
            if (enemiesLeftToSpawn > 0)
            {
            Vector3 spawnPos = GetRandomPositionOnPlane();
                GameObject enemyInstance = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
                Enemy enemyScript = enemyInstance.GetComponent<Enemy>();

                // Set properties for the enemy based on the current wave
                enemyScript.SetSpeed(waves[currentWaveIndex].enemySpeed);
                enemyScript.SetHealth(waves[currentWaveIndex].enemyHealth);

                // Decrement the count of enemies left to spawn
                enemiesLeftToSpawn--;

                // Subscribe to the enemy's death event
                enemyScript.OnDeath.AddListener(EnemyDied);
            }
            else
            {
                CancelInvoke("SpawnEnemy");
            }
        }
    [Space]
    [Header("spawning")]
    public Transform planeTransform;
    public float yPos;
    private Vector3 GetRandomPositionOnPlane()
    {
        Renderer planeRenderer = planeTransform.GetComponent<Renderer>();
        Vector3 minBounds = planeRenderer.bounds.min;
        Vector3 maxBounds = planeRenderer.bounds.max;

        float x = Random.Range(minBounds.x, maxBounds.x);
        float z = Random.Range(minBounds.z, maxBounds.z);

        if(yPos==0)
        return new Vector3(x, planeTransform.position.y, z);
        else
        return new Vector3(x, yPos, z);
    }

    private void EnemyDied()
        {
            enemiesAlive--;
            if (enemiesAlive <= 0)
            {
                // All enemies in the current wave are dead, wait for a bit and then start the next wave
                currentWaveIndex++;
                Invoke("StartNextWave", timeBetweenWaves);
            }
        }
    }

