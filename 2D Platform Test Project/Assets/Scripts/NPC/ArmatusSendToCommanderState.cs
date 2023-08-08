using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmatusSendToCommanderState : BaseState
{
    Dialogue dialogue;
    public ArmatusSendToCommanderState(NPC npc) : base(npc)
    {
        string sentence1 = "You were pretty impressive in the ring!";
        string sentence2 = "You better get back to the commander, he will assign you some work to do now that you are fit for duty.";
        dialogue = new Dialogue();
        dialogue.sentences.Add(sentence1);
        dialogue.sentences.Add(sentence2);
        dialogue.HasTabletPuzzle = false;
        dialogue.ConversationComplete = false;
        dialogue.ForcedDialogue = true;
        dialogue.name = "Gaius Armatus";

    }
    public override void EnterState()
    {
        npc.AssignDialogue(dialogue);



        UIManager.Instance.ContinueButton.SetActive(false);
        FortGuide.Instance.SetObjectivecomplete(FortGuide.FortObjective.Tutorial);
    }

    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {

    }
}
