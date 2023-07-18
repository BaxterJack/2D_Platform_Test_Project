using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestQuizState : BaseState
{
    Dialogue dialogue;

    public PriestQuizState(NPC npc) : base(npc)
    {



    }

    public override void EnterState()
    {
        GameManager.Instance.ActivateGodsQuiz();
    }

    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {

    }
}
