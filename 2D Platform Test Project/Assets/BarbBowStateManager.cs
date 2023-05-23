using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbBowStateManager : MonoBehaviour
{
    BarbBaseState currentState;
    public BarbPatrolState patrolState;
    public BarbDeathState deathState;

    [SerializeField]
    public Vector2[] waypoints;

    [SerializeField]
    public float speed = 1.0f;

    [SerializeField]
    public AiSight aiSight;

    [SerializeField]
    public GameObject player;

    public Vector2 target;
    public Vector2 direction;
    public Vector2 destination;

    [SerializeField]
    public HealthBar healthBar;

    [SerializeField]
    public BarbarianAnimation barbarianAnimation;

    public float attackCoolDown = 0.0f;

    void Start()
    {
        //patrolState = new BarbPatrolState(this);
        
        
        //deathState = new BarbDeathState(this);
        //currentState = patrolState;
        //currentState.EnterState(this);

    }

    void Update()
    {
        //currentState.UpdateState(this);
        if (attackCoolDown > 0.0f)
        {
            attackCoolDown -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        //currentState.FixedUpdateState(this);
    }

    public void SwitchState(BarbBaseState state)
    {
        currentState = state;
        //state.EnterState(this);
    }
}
