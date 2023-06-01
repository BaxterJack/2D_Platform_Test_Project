using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootState : BaseState
{
    bool isShooting = false;
    GameObject arrow;
    Transform arrowPosition;
    BarbBowmen barbBowmen;
    public ShootState(AiObject AiObject, BarbBowmen BarbBowmen) : base(AiObject)
    {
        barbBowmen = BarbBowmen;
        aiObject.attackCoolDown = 2.5f;
    }
    public override void EnterState()
    {

    }

    public override void UpdateState()
    {
        aiObject.SetAttackOffset();
        aiObject.SetTarget(aiObject.GetPlayerPosition());
        isShooting = aiObject.barbarianAnimation.animator.GetCurrentAnimatorStateInfo(0).IsName("BarbSlashAnim");
        if (!isShooting && aiObject.attackCoolDown >= 1.5f)
        {
            aiObject.attackCoolDown = 0.0f;
            barbBowmen.Shoot();
        }
        else
        {
            aiObject.attackCoolDown += Time.deltaTime;
        }
    }

    public override void FixedUpdateState()
    {

    }


}
