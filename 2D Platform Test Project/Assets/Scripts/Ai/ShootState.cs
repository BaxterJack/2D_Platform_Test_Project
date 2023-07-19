using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootState : BaseState
{
    bool isShooting = false;
    GameObject arrow;
    Transform arrowPosition;
    BarbBowmen barbBowmen;
    float coolDownLimit;

    public ShootState(AiObject AiObject, BarbBowmen BarbBowmen) : base(AiObject)
    {
        barbBowmen = BarbBowmen;
        aiObject.attackCoolDown = 2.5f;
        coolDownLimit = 2.0f;
    }
    public override void EnterState()
    {

    }

    public override void UpdateState()
    {
        aiObject.SetAttackOffset();
        aiObject.SetTarget(aiObject.GetPlayerPosition());
        isShooting = aiObject.barbarianAnimation.animator.GetCurrentAnimatorStateInfo(0).IsName("BarbSlashAnim");
        if (!isShooting && aiObject.attackCoolDown >= coolDownLimit)
        {
            aiObject.attackCoolDown = 0.0f;
            barbBowmen.Shoot();
        }
        else
        {
            aiObject.attackCoolDown += Time.deltaTime;
            Debug.Log("Cant shoot yet");
        }
    }

    public override void FixedUpdateState()
    {

    }


}
