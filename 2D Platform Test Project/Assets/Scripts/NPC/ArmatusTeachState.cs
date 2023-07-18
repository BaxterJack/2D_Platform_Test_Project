using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmatusTeachState : BaseState
{
    Dialogue dialogue;
    public ArmatusTeachState(NPC npc) : base(npc)
    {
        string sentence1 = "I can teach you about Roman Military Tactics.";
        dialogue = new Dialogue();
        dialogue.sentences.Add(sentence1);
       
        dialogue.HasTabletPuzzle = false;
        dialogue.ConversationComplete = false;
        dialogue.name = "Gaius Armatus";
        
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
