using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbStateManager : MonoBehaviour
{
    BarbBaseState currentState;
    public BarbPatrolState patrolState;
    public BarbGoToAttackPosState goToAttackPosState ;
    public BarbAttackState attackState = new BarbAttackState();

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


    void Start()
    {
        patrolState = new BarbPatrolState(this);
        goToAttackPosState = new BarbGoToAttackPosState(this);
        currentState = patrolState;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
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
