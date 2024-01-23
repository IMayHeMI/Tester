using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private LevelManager levelManager;

    [SerializeField] private Transform enemySpawnPoint;

    [SerializeField] private Enemy enemyModel;

    [SerializeField] private GameObject enemy;

    private float spawnTime;

    private float currentSpawnTime;

    [SerializeField] private float maxSpawnCooldown;

    private readonly float minSpawnCooldown = 3;

    private int enemyCounter;

    private bool isSpawned = true;

    private void Start()
    {
        spawnTime = Random.Range(minSpawnCooldown, maxSpawnCooldown);
        currentSpawnTime = spawnTime;
        levelManager = GameObject.Find("Level_Manager").GetComponent<LevelManager>();
    }

    void Update()
    {
        SpawnEnemy();
        if (isSpawned) SpawnTiming();
        SpawnTimeReset();
    }

    public void SpawnEnemy()
    {
        //enemyModel.SetEnemyStats(EnemyType.Junior);
        if (currentSpawnTime == spawnTime)
        {
            Instantiate(enemy, enemySpawnPoint.position, enemySpawnPoint.rotation);
            enemyCounter++;
            levelManager.LevelEnemyCounter = enemyCounter;
            isSpawned = true;
        }        
    }

    public void SpawnTimeReset()
    {
        if (maxSpawnCooldown < 4)
        {
            maxSpawnCooldown = 4f;
        }

        if (currentSpawnTime <= 0)
        {
            spawnTime = Random.Range(minSpawnCooldown, maxSpawnCooldown);
            currentSpawnTime = spawnTime;
            isSpawned = false;
        }
    }

    public void SpawnTiming()
    {
        currentSpawnTime -= Time.deltaTime;    
    }
}
