using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiObject : MonoBehaviour
{

    public StateMachine stateMachine;

    [SerializeField]
    public GameObject[] waypoints;

    [SerializeField]
    public float speed = 1.0f;

    [SerializeField]
    public AiSight aiSight;

    [SerializeField]
    public GameObject player;

    [SerializeField]
    public HealthBar healthBar;

    [SerializeField]
    public BarbarianAnimation barbarianAnimation;

    [SerializeField]
    public Attack_Point attackPoint;

    [SerializeField]
    public LayerMask playerLayers;

    public float attackOffset;

    public float attackCoolDown = 0.0f;

    public Vector2 target;
    public Vector2 direction;
    public Vector2 destination;

    public float distanceToTarget;

    private void Start()
    {
      
    }

    public void MoveAI()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        Vector2 velocity = rigidbody.velocity;
        Vector2 barbPosition = rigidbody.transform.transform.position;
        direction = (barbPosition - destination);
        velocity.x = direction.normalized.x * -speed;
        GetComponent<Rigidbody2D>().velocity = velocity;
    }

    public void SetAttackOffset()
    {
        attackOffset = (transform.position.x - GetComponentInChildren<Attack_Point>().transform.position.x) * 1.25f;
        destination = player.transform.localPosition;
        target = destination;
        destination.x += attackOffset;
        distanceToTarget = (destination - (Vector2)transform.position).magnitude;
    }
}

