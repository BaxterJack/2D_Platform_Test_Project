using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VitalisBathHouseComplete : BaseState
{
    Dialogue dialogue;

    public VitalisBathHouseComplete(NPC npc) : base(npc)
    {
        string sentence1 = "Thanks so much for finsihing the Bath House. Now it's ready for use!";
        //string sentence2 = "Let me teach you about it.";


        dialogue = new Dialogue();
        dialogue.sentences.Add(sentence1);
        //dialogue.sentences.Add(sentence2);
        dialogue.HasTabletPuzzle = false;
        dialogue.name = "Vitalis";


    }

    public override void EnterState()
    {
        npc.AssignDialogue(dialogue);
    }

    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {

    }
}
