using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;

    //Health
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthBar;

    //Combat
    public int attackDamage = 1;
    public float attackRange = 1.5f;
    public LayerMask enemyLayer;

    //Animation
    private Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        healthBar.maxValue = maxHealth;
        healthBar.minValue = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Punch();
        Kick();
    }

    //Movement

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("vertical");

            Vector3 move = new Vector3(x, 0, z);
            transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

            animator.SetFloat("Speed", move.magnitude);
        }
    }

    //Punch
    void Punch()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Punch");
            DealDamage();
        }
    }

    //Kick
    void Kick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Kick");
            DealDamage();
        }

    }

    void DealDamage()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().Takedamage(attackDamage);
        }
    }

    //Take Damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.value = currentHealth;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetTrigger("Death");
        //Later: restart or menu
    }

    //Power-ups
    public void StrengthBoost()
    {
        attackDamage += 2;
    }

    public void FullHeal()
    {
        currentHealth = maxHealth;
        healthBar.value = currentHealth;
    }
}
