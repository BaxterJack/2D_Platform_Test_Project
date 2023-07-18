using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmatusWelcomeState : BaseState
{
    Dialogue dialogue;
    public ArmatusWelcomeState(NPC npc) : base(npc)
    {
        string sentence1 = "Welcome, I am Gaius Armatus, the Master at Arms at Fort Vindolanda.";
        string sentence2 = "You must be the new recruit. Lets see what you're made of.";
        dialogue = new Dialogue();
        dialogue.sentences.Add(sentence1);
        dialogue.sentences.Add(sentence2);
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

