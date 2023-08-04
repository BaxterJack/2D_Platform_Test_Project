using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbAxeman : AiObject
{
    protected PatrolState patrolState;
    protected AttackState attackState;
    protected DeathState deathState;
    protected GoToAttackPosState goToAttackPosState;
    [SerializeField] protected int slashDamage;
    protected override void Start()
    {
        base.Start();
        InitStates();
        InitStateTransitions();
        InitInitialState();

        type = this.GetType().Name;
        SetXP(type);
        slashDamage = 25;
        attackAnim = "BarbSlashAnim";
        Debug.Log("BarbAxeman");
    }

    protected void InitStates()
    {
        stateMachine = new StateMachine();
        patrolState = new PatrolState(this);
        attackState = new AttackState(this);
        deathState = new DeathState(this);
        goToAttackPosState = new GoToAttackPosState(this);
    }

    protected void InitInitialState()
    {
        stateMachine.SetInitialState(patrolState);
    }
    protected void InitStateTransitions()
    {
        stateMachine.AddTransition(new StateTransition(patrolState, goToAttackPosState, this.aiSight.CanSeePlayer));
        stateMachine.AddTransition(new StateTransition(patrolState, deathState, this.healthBar.HasNoHealth));
        stateMachine.AddTransition(new StateTransition(goToAttackPosState, patrolState, this.aiSight.CannotSeePlayer));
        stateMachine.AddTransition(new StateTransition(goToAttackPosState, deathState, this.healthBar.HasNoHealth));
        stateMachine.AddTransition(new StateTransition(goToAttackPosState, attackState, this.IsInRangeOfTarget));
        stateMachine.AddTransition(new StateTransition(attackState, deathState, this.healthBar.HasNoHealth));
        stateMachine.AddTransition(new StateTransition(attackState, goToAttackPosState, this.HasJustAttacked));
    }

    protected override void Awake()
    {
        base.Awake();
    }

    void Update()
    {
        stateMachine.Update();

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
            player.GetComponentInChildren<HealthBar>().TakeDamage(slashDamage);
            ApplyKnockBack();
            AudioManager audioManager = AudioManager.Instance;
            audioManager.PlaySound("Hit");
        }
    }

    protected void ApplyKnockBack()
    {
        Vector2 knockBackDirection = (this.PlayerPosition - (Vector2)transform.position);
        knockBackDirection.y = 0;
        player.GetComponent<Rigidbody2D>().AddForce(knockBackDirection.normalized * knockBackForce);
    }

    public void SetHasAttackedTrue() // used in animation event
    {
       HasAttacked = true;
    }
}

