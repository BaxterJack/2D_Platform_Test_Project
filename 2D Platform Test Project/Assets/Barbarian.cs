using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barbarian : MonoBehaviour
{
    [SerializeField]
    Vector2[] waypoints;
    Vector2 direction;

    [SerializeField]
    float speed = 1.0f;

    int numWaypoints;
    int currentWaypoint;

    [SerializeField]
    int maxHealth = 20;
    int currentHealth;

    [SerializeField]
    HealthBar healthBar;

    [SerializeField]
    AiSight aiSight;

    [SerializeField]
    BarbarianAnimation barbarianAnimation;


    void Start()
    {
        numWaypoints = waypoints.Length;
        currentWaypoint = 0;
        currentHealth = maxHealth;
    }

    void Update()
    {
      
        
    }

    private void FixedUpdate()
    {
        if (!barbarianAnimation.IsAiDead())
        {
            MoveAI();
        }
        if (direction.magnitude < 0.35f)
        {
            ChooseNextWaypoint();
        }
    }


    void MoveAI()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        Vector2 velocity = rigidbody2D.velocity;
        Vector2 barbPosition = rigidbody2D.transform.transform.position;
        Vector2 waypointPosition = waypoints[currentWaypoint];
        direction = (barbPosition - waypointPosition);
        velocity.x = direction.normalized.x * -speed;
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
            barbarianAnimation.Die();
        }
    }


}
