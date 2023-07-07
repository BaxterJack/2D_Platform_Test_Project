using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbBowmen : AiObject
{
    [SerializeField]
    GameObject arrow;
    [SerializeField]
    Transform arrowPosition;
    public PatrolState patrolState;
    public ShootState shootState;
    public DeathState deathState;

    void Start()
    {
        patrolState = new PatrolState(this);
        deathState = new DeathState(this);
        shootState = new ShootState(this, this);
        stateMachine = new StateMachine();
        //stateMachine.AddState(patrolState);
        //stateMachine.AddState(deathState);
        stateMachine.SetInitialState(patrolState);

        stateMachine.AddTransition(new StateTransition(patrolState, deathState, this.healthBar.HasNoHealth));
        stateMachine.AddTransition(new StateTransition(patrolState, shootState, this.aiSight.CanSeePlayer));
        stateMachine.AddTransition(new StateTransition(shootState, deathState, this.healthBar.HasNoHealth));
        stateMachine.AddTransition(new StateTransition(shootState, patrolState, this.aiSight.CannotSeePlayer));
        FindPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }

    void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }

    public void Shoot()
    {
        barbarianAnimation.Shoot();
        
    }

    public void IntanstiateArrow()
    {
        Instantiate(arrow, arrowPosition.position, Quaternion.identity);
    }
}
