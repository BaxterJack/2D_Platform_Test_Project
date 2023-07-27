using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LepidinaArtefactQuiz : BaseState
{
    public LepidinaArtefactQuiz(NPC npc) : base(npc)
    {


    }


    public override void EnterState()
    {
        GameManager.Instance.InstatiateQuiz("ArtefactQuiz", QuizManager.QuizType.Artefact);
    }

    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {


    }
}
