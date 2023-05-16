using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barbarian : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Vector2[] waypoints;

    [SerializeField]
    float speed = 1.0f;

    int numWaypoints;
    int currentWaypoint;

    bool isMoving = false;
    float horizontalMove = 0.0f;

    [SerializeField]
    Animator animator;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    int maxHealth = 20;
    int currentHealth;

    [SerializeField]
    HealthBar healthBar;

    bool hasDied;

    void Start()
    {
        numWaypoints = waypoints.Length;
        currentWaypoint = 0;
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasDied)
        {
            return;
        }
        SpriteAnimation();
    }

    private void FixedUpdate()
    {
        if(hasDied)
        {
            return;
        }
        MoveAI();
    }

    void SpriteAnimation()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        horizontalMove = rigidbody2D.velocity.x;

        isMoving = horizontalMove != 0;
        animator.SetBool("IsBarbMoving", isMoving);

        if (horizontalMove > 0.0f)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalMove < 0.0f)
        {
            spriteRenderer.flipX = false;
        }
    }

    void MoveAI()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        Vector2 velocity = rigidbody2D.velocity;
        Vector2 barbPosition = rigidbody2D.transform.transform.position;
        Vector2 waypointPosition = waypoints[currentWaypoint];
        Vector2 direction = (barbPosition - waypointPosition);
        if (direction.magnitude < 0.35f)
        {
            ChooseNextWaypoint();
        }
        direction = (barbPosition - waypointPosition).normalized;
        velocity.x = direction.x * -speed;
        rigidbody2D.velocity = velocity;
    }
    void ChooseNextWaypoint()
    {
        currentWaypoint++;
        if(currentWaypoint == numWaypoints)
        {
            currentWaypoint = 0;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0) 
        {
            Die();
        }
    }

    void Die()
    {
        hasDied = true;
        animator.SetBool("HasDied", hasDied);
        GetComponent<Rigidbody2D>().gravityScale = 0.0f;
        GetComponent<Rigidbody2D>().Sleep();
        GetComponent<Collider2D>().enabled = false;

        this.enabled = false;
    }
}
