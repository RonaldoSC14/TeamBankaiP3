using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject strengthPowerUp;
    public Transform enemySpawnPoint;

    private int enemyHealth = 10;

    private int enemyDamage = 1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyDefeated()
    {
        SpawnPowerUp();

        enemyHealth += 5;
        enemyDamage += 1;

        SpawnEnemy();

    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, enemySpawnPoint.position, Quaternion.identity);

        Enemy ai = enemy.GetComponent<Enemy>();

        ai.maxHealth = enemyHealth;
        ai.currentHealth = enemyHealth;
        ai.damage = enemyDamage;
    }

    void SpawnPowerUp()
    {
        Instantiate(strengthPowerUp,enemySpawnPoint.position, Quaternion.identity);
    }
}
