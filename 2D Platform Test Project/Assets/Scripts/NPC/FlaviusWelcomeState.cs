using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaviusWelcomeState : BaseState
{
    Dialogue dialogue;
    public FlaviusWelcomeState(NPC npc) : base(npc)
    {
        string sentence1 = "Welcome to Fort Vindolanda Soldier, my names is Flavius Cerialis. I am the fort commander.";
        string sentence2 = "First, you'll need to head to the training grounds to make sure you're fit for service.";
        string sentence3 = "You'll find the Master at Arms, Gaius Armatus, at the training grounds next to the blacksmith.";
        string sentence4 = "Come on now, hop to it!!";

        dialogue = new Dialogue();
        dialogue.sentences.Add(sentence1);
        dialogue.sentences.Add(sentence2);
        dialogue.sentences.Add(sentence3);
        dialogue.sentences.Add(sentence4);
        dialogue.HasTabletPuzzle = false;
        dialogue.name = "Flavius Cerialis";
        

    }

    
    public override void EnterState()
    {
        npc.AssignDialogue(dialogue);
    }

    public override void UpdateState()
    {
        //npc.SetDestination();
    }

    public override void FixedUpdateState()
    {
        //npc.MoveNPC(npc.destinationWaypoint);
    }
}
