using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LepidinaSendOtherQuiz : BaseState
{
    Dialogue dialogue;
    public LepidinaSendOtherQuiz(NPC npc) : base(npc)
    {
        string sentence1 = "You did excellent!";
        string sentence2 = "If you haven't already spoken with Marcus Flavus the priest, Valerius Vulcanius the blacksmith and Gaius Armatus the Master at Arms.";
        string sentence3 = "I'm sure they'd love to test your knowledge too!";

        dialogue = new Dialogue();
        dialogue.sentences.Add(sentence1);
        dialogue.sentences.Add(sentence2);
        dialogue.sentences.Add(sentence3);


        dialogue.HasTabletPuzzle = false;
        dialogue.ForcedDialogue = true;
        dialogue.name = "Lady Lepidina";

    }


    public override void EnterState()
    {
        npc.AssignDialogue(dialogue);
        FortGuide.Instance.SetObjectivecomplete(FortGuide.FortObjective.AretefactsQuiz);
    }

    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {


    }
}
