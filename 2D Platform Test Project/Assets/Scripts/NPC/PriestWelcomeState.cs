using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestWelcomeState : BaseState
{
    Dialogue dialogue;

    public PriestWelcomeState(NPC npc) : base(npc)
    {
        string sentence1 = "Hello, my name is Marcus Flavus, I am the priest at Fort Vindolanda.";
        string sentence2 = "You worship the Gods right?";
        string sentence3 = "Of course you do!?";
        string sentence4 = "Let me test your devotion then.";


        dialogue = new Dialogue();
        dialogue.sentences.Add(sentence1);
        dialogue.sentences.Add(sentence2);
        dialogue.sentences.Add(sentence3);
        dialogue.sentences.Add(sentence4);
        dialogue.HasTabletPuzzle = false;
        dialogue.name = "Marcus Flavus";


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
