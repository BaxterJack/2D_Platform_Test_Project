using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbAxeman : AiObject
{
    public PatrolState patrolState;
    public AttackState attackState;
    public DeathState deathState;
    public GoToAttackPosState goToAttackPosState;

    BarbAxemanDelegates barbAxemanDelegates;
    StateTransition stateTransition;
    void Start()
    {
        barbAxemanDelegates = new BarbAxemanDelegates(this);
        patrolState = new PatrolState(this);
        attackState = new AttackState(this);
        deathState = new DeathState(this);
        stateMachine = new StateMachine(this, barbAxemanDelegates);
        goToAttackPosState = new GoToAttackPosState(this);
        stateMachine.currentState = patrolState;
        barbAxemanDelegates = new BarbAxemanDelegates(this);
        stateTransition = new StateTransition(patrolState, deathState, /*barbAxemanDelegates.CanSeePlayer*/ this.aiSight.CanSeePlayer);
    }

    void Update()
    {
        stateMachine.Update();
    }

    void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }


}

public class BarbAxemanDelegates : BaseDelegates
{
    public SeePlayer seePlayerPtr;
    public NoHealth noHealthPtr;
    public BarbAxemanDelegates(AiObject AiObject) : base(AiObject)
    {
        seePlayerPtr = new SeePlayer(CanSeePlayer);
        noHealthPtr = new NoHealth(HasNoHealth);
    }

    public delegate bool SeePlayer();

    public bool CanSeePlayer()
    {
        return aiObject.aiSight.CanSeePlayer();
    }

    public delegate bool NoHealth();

    public bool HasNoHealth()
    {
        return aiObject.healthBar.currentHealth <= 0;
    }
}