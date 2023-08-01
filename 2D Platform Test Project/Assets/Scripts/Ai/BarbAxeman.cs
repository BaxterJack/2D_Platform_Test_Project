using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbAxeman : AiObject
{
    public PatrolState patrolState;
    public AttackState attackState;
    public DeathState deathState;
    public GoToAttackPosState goToAttackPosState;

    protected override void Start()
    {
        base.Start();
        patrolState = new PatrolState(this);
        attackState = new AttackState(this);
        deathState = new DeathState(this);
        goToAttackPosState = new GoToAttackPosState(this);

        stateMachine = new StateMachine();
        stateMachine.SetInitialState(patrolState);
        stateMachine.AddTransition(new StateTransition(patrolState, goToAttackPosState, this.aiSight.CanSeePlayer));
        stateMachine.AddTransition(new StateTransition(patrolState, deathState, this.healthBar.HasNoHealth));
        stateMachine.AddTransition(new StateTransition(goToAttackPosState, patrolState, this.aiSight.CannotSeePlayer));
        stateMachine.AddTransition(new StateTransition(goToAttackPosState, deathState, this.healthBar.HasNoHealth));
        stateMachine.AddTransition(new StateTransition(goToAttackPosState, attackState, this.IsInRangeOfTarget));
        stateMachine.AddTransition(new StateTransition(attackState, deathState, this.healthBar.HasNoHealth));
        stateMachine.AddTransition(new StateTransition(attackState, goToAttackPosState, this.HasJustAttacked));
        type = this.GetType().Name;
        SetXP(type);
    }

    protected override void Awake()
    {
        base.Awake();
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
            ApplyKnockBack();
            AudioManager audioManager = AudioManager.Instance;
            audioManager.PlaySound("Hit");
        }
    }

    private void ApplyKnockBack()
    {
        Vector2 knockBackDirection = (this.PlayerPosition - (Vector2)transform.position);
        knockBackDirection.y = 0;
        player.GetComponent<Rigidbody2D>().AddForce(knockBackDirection.normalized * knockBackForce);
    }

    void SetHasAttackedTrue() // used in animation event
    {
       HasAttacked = true;
    }
}

