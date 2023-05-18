using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbStateManager : MonoBehaviour
{
    BarbBaseState currentState;
    public BarbPatrolState patrolState;// = new BarbPatrolState(GetComponent<GameObject>());
    public BarbGoToAttackPosState goToAttackPosState = new BarbGoToAttackPosState();
    public BarbAttackState attackState = new BarbAttackState();

    [SerializeField]
    public Vector2[] waypoints;

    [SerializeField]
    public float speed = 1.0f;


    void Start()
    {
        patrolState = new BarbPatrolState(this);
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
