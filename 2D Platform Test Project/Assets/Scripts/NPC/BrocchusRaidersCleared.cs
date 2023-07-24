using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrocchusRaidersCleared : BaseState
{
    Dialogue dialogue;

    public BrocchusRaidersCleared(NPC npc) : base(npc)
    {
        string sentence1 = "Thank you for clearing those Raiders Soldier. You really saved the day!";
        string sentence2 = "Someone really needs to build a wall to stop them!!";
        string sentence3 = "My name is Aelius Brocchus, I am the Fort commander at Newbrough.";


        dialogue = new Dialogue();
        dialogue.sentences.Add(sentence1);
        dialogue.sentences.Add(sentence2);
        dialogue.sentences.Add(sentence3);
        dialogue.HasTabletPuzzle = false;
        dialogue.name = "Aelius Brocchus";


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
