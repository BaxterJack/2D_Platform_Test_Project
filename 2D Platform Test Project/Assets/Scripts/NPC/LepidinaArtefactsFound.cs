using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LepidinaArtefactsFound : BaseState
{
    Dialogue dialogue;
    public LepidinaArtefactsFound(NPC npc) : base(npc)
    {
        string sentence1 = "You found my slippers!";
        string sentence2 = "Thanks you so much, I feared I had lost them for millenia.";
        string sentence3 = "So, are you ready for the quiz?";
        string sentence4 = "Excellent. Here we go.";

        dialogue = new Dialogue();
        dialogue.sentences.Add(sentence1);
        dialogue.sentences.Add(sentence2);
        dialogue.sentences.Add(sentence3);
        dialogue.sentences.Add(sentence4);


        dialogue.HasTabletPuzzle = false;
        dialogue.ForcedDialogue = false;
        dialogue.name = "Lady Lepidina";

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
