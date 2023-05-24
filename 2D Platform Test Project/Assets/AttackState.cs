using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    
    bool isAttacking;
    float timeSinceAttack = 0.0f;
    public AttackState(AiObject AiObject) : base(AiObject)
    {

    }

    public override void EnterState()
    {

    }

    public override void UpdateState()
    {
        aiObject.SetAttackOffset();
    }

    public override void FixedUpdateState()
    {

    }

    void SlashAttack()
    {
        aiObject.barbarianAnimation.Slash();
    }

    void ApplyDamage()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(aiObject.attackPoint.transform.position, aiObject.attackPoint.attackRange, aiObject.playerLayers);

        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponentInChildren<HealthBar>().TakeDamage(20);
            Debug.Log("We hit " + player.name);
        }
    }
}
