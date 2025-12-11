using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 10;
    public int currentHealth;
    public int damage = 1;
    public float moveSpeed = 3f;
    public float attackRange = 1.5f;

    private Transform player;
    private EnemySpawner spawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        
        spawner = FindObjectOfType<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if(distance > attackRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            AttackPlayer();
        }
    }

    void AttackPlayer()
    {
        player.GetComponent<PlayerControl>().TakeDamage(damage);
    }

    public void Takedamage(int dmg)
    {
        currentHealth -= dmg;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        spawner.EnemyDefeated();
        Destroy(gameObject);
    }




}
