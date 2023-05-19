using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barbarian : MonoBehaviour
{
    //[SerializeField]
    //Vector2[] waypoints;
    //Vector2 direction;

    //[SerializeField]
    //float speed = 1.0f;

    //int numWaypoints;
    //int currentWaypoint;

    //[SerializeField]
    //int maxHealth = 20;
    //int currentHealth;

    //[SerializeField]
    //HealthBar healthBar;

    //[SerializeField]
    //AiSight aiSight;

    //[SerializeField]
    //BarbarianAnimation barbarianAnimation;

    ////[SerializeField]
    ////GameObject player;

    ////Vector2 destination;

    ////Vector2 target;

    //public float attackOffset;

    void Start()
    {
        //numWaypoints = waypoints.Length;
        //currentWaypoint = 0;
        //destination = waypoints[currentWaypoint];
        //target = destination;
        //currentHealth = maxHealth;
        
    }

    void Update()
    {
        //attackOffset = (transform.position.x - GetComponentInChildren<Attack_Point>().transform.position.x) *1.25f;
        //if (aiSight.CanSeePlayer())
        //{          
        //    destination = player.transform.localPosition ;
        //    target = destination;
        //    destination.x += attackOffset;
        //}
        //else if (direction.magnitude < 0.35f)
        //{
        //    //ChooseNextWaypoint();
        //}

    }

    private void FixedUpdate()
    {
        //if (!barbarianAnimation.IsAiDead())
        //{
        //   //MoveAI();
        //}
    }

    //void MoveAI()
    //{
    //    Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
    //    Vector2 velocity = rigidbody2D.velocity;
    //    Vector2 barbPosition = rigidbody2D.transform.transform.position;
    //    direction = (barbPosition - destination);
    //    velocity.x = direction.normalized.x * -speed;
    //    rigidbody2D.velocity = velocity;   
    //}
    //void ChooseNextWaypoint()
    //{
    //    currentWaypoint++;
    //    if(currentWaypoint == numWaypoints)
    //    {
    //        currentWaypoint = 0;
    //    }
    //    destination = waypoints[currentWaypoint];
    //    target = destination;
    //}

    //public void TakeDamage(int damage)
    //{
    //    currentHealth -= damage;
    //    healthBar.SetHealth(currentHealth);

    //    if (currentHealth <= 0) 
    //    {
    //        barbarianAnimation.Die();
    //    }
    //}

    //public Vector2 GetTarget()
    //{
    //    return target;
    //}
}
