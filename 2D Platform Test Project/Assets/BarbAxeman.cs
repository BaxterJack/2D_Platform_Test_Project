using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbAxeman : AiObject
{
    public PatrolState patrolState;
    public AttackState attackState;
    public DeathState deathState;
    public GoToAttackPosState goToAttackPosState;


    StateTransition stateTransition;

    BarbAxeman()
    {
      
    }
    void Start()
    {

        patrolState = new PatrolState(this);
        attackState = new AttackState(this);
        deathState = new DeathState(this);
        goToAttackPosState = new GoToAttackPosState(this);
        //stateMachine.currentState = patrolState;
        //stateTransition = new StateTransition(patrolState, deathState, this.aiSight.CanSeePlayer);

        stateMachine = new StateMachine();
        stateMachine.AddState(patrolState);
        stateMachine.AddState(goToAttackPosState);
        stateMachine.AddTransition(new StateTransition(patrolState, goToAttackPosState, this.aiSight.CanSeePlayer));
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

//public class BarbAxemanDelegates : BaseDelegates
//{
//    public SeePlayer seePlayerPtr;
//    public NoHealth noHealthPtr;
//    public BarbAxemanDelegates(AiObject AiObject) : base(AiObject)
//    {
//        seePlayerPtr = new SeePlayer(CanSeePlayer);
//        noHealthPtr = new NoHealth(HasNoHealth);
//    }

//    public delegate bool SeePlayer();

//    public bool CanSeePlayer()
//    {
//        return aiObject.aiSight.CanSeePlayer();
//    }

//    public delegate bool NoHealth();

//    public bool HasNoHealth()
//    {
//        return aiObject.healthBar.currentHealth <= 0;
//    }
//}