using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbBowmen : AiObject
{

    public PatrolState patrolState;
    public DeathState deathState;

    void Start()
    {
        patrolState = new PatrolState(this);
        deathState = new DeathState(this);

        stateMachine = new StateMachine();
        stateMachine.AddState(patrolState);
        stateMachine.AddState(deathState);


        stateMachine.AddTransition(new StateTransition(patrolState, deathState, this.healthBar.HasNoHealth));
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
}
