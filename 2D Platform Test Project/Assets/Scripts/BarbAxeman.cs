using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbAxeman : AiObject
{
    public PatrolState patrolState;
    public AttackState attackState;
    public DeathState deathState;
    public GoToAttackPosState goToAttackPosState;

    void Start()
    {

        patrolState = new PatrolState(this);
        attackState = new AttackState(this);
        deathState = new DeathState(this);
        goToAttackPosState = new GoToAttackPosState(this);

        stateMachine = new StateMachine();
        //stateMachine.AddState(patrolState);
        //stateMachine.AddState(goToAttackPosState);
        stateMachine.SetInitialState(patrolState);
        stateMachine.AddTransition(new StateTransition(patrolState, goToAttackPosState, this.aiSight.CanSeePlayer));
        stateMachine.AddTransition(new StateTransition(patrolState, deathState, this.healthBar.HasNoHealth));
        stateMachine.AddTransition(new StateTransition(goToAttackPosState, patrolState, this.aiSight.CannotSeePlayer));
        stateMachine.AddTransition(new StateTransition(goToAttackPosState, deathState, this.healthBar.HasNoHealth));
        stateMachine.AddTransition(new StateTransition(goToAttackPosState, attackState, this.IsInRangeOfTarget));
        stateMachine.AddTransition(new StateTransition(attackState, deathState, this.healthBar.HasNoHealth));
        stateMachine.AddTransition(new StateTransition(attackState, goToAttackPosState, this.HasJustAttacked));
    }

    void Update()
    {
        stateMachine.Update();
        Debug.DrawLine(transform.position, destination, Color.red);
    }

    void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }

    public void ApplySlashDamage()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(this.attackPoint.transform.position, this.attackPoint.attackRange, this.playerLayers);

        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponentInChildren<HealthBar>().TakeDamage(20);
            AudioManager audioManager = AudioManager.Instance;
            audioManager.PlaySound("Hit");
            //Debug.Log("We hit " + player.name);
        }
    }

    void SetHasAttackedTrue()
    {
        this.hasAttacked = true;
    }
}

