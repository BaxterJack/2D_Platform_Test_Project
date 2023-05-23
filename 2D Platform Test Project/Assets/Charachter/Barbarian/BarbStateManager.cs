using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbStateManager : MonoBehaviour
{
    BarbBaseState currentState;
    public BarbPatrolState patrolState;
    public BarbGoToAttackPosState goToAttackPosState ;
    public BarbAttackState attackState;
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

    [SerializeField]
    public Attack_Point attackPoint;

    [SerializeField]
    public LayerMask playerLayers;

    public float attackOffset;

    public float attackCoolDown = 0.0f;

    void Start()
    {
        patrolState = new BarbPatrolState(this);
        goToAttackPosState = new BarbGoToAttackPosState();
        attackState = new BarbAttackState();
        deathState = new BarbDeathState();
        currentState = patrolState;
        currentState.EnterState(this);
        
    }

    void Update()
    {
        currentState.UpdateState(this);
        if(attackCoolDown > 0.0f)
        {
            attackCoolDown -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
    }

    public void SwitchState(BarbBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }


}
