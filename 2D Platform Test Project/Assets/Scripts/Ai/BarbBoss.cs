using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbBoss : BarbAxeman
{
    protected override void Awake()
    {
        base.Awake();

        type = this.GetType().Name;

    }
    protected override void Start()
    {
        base.Start();
        InitStates();
        InitInitialState();
        InitStateTransitions();
        type = this.GetType().Name;
        SetXP(type);
        slashDamage = 35;
        attackAnim = "BarbBossSlashAnim";
        Debug.Log("BarbBoss");
    }

    
    void Update()
    {
        stateMachine.Update();
    }

    void FixedUpdate()
    {
        //Debug.Log(stateMachine.currentState);
        stateMachine.FixedUpdate();
    }
}
