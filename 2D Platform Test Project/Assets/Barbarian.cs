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

    void Start()
    {
        numWaypoints = waypoints.Length;
        currentWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SpriteAnimation();
    }

    private void FixedUpdate()
    {
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
        if (direction.magnitude < 0.25f)
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
}
