using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaviusTabletOne : BaseState
{
    Dialogue dialogue;
    public FlaviusTabletOne(NPC npc) : base(npc)
    {
        string sentence1 = "Gauis Armatus says you did well on the training ground. It looks like your fit for duty!";
        string sentence2 = "I have some other tasks for you, you can read can't you?";
        string sentence3 = "Excellent, Ok well take a look at this message to make sure you can read Roman Cursive";
        string sentence4 = "Then you can deliver the message to the Fort Priest, Marcus Flavus.";

        dialogue = new Dialogue();
        dialogue.sentences.Add(sentence1);
        dialogue.sentences.Add(sentence2);
        dialogue.sentences.Add(sentence3);
        dialogue.sentences.Add(sentence4);
        dialogue.HasTabletPuzzle = true;
        dialogue.name = "Flavius Cerialis";
        dialogue.ForcedDialogue = false;


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
