using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VulcaniusWelcome : BaseState
{
    Dialogue dialogue;
    public VulcaniusWelcome(NPC npc) : base(npc)
    {
        string sentence1 = "Are you the new recruit? Shouldn't you be completing basic training?";
        string sentence2 = "When you've done that, come back to me for a challenge.";
        string sentence3 = "If you do well, I'll make some improvemnts to your armour!";
        dialogue = new Dialogue();
        dialogue.sentences.Add(sentence1);
        dialogue.sentences.Add(sentence2);
        dialogue.sentences.Add(sentence3);
        dialogue.HasTabletPuzzle = false;
        dialogue.ConversationComplete = false;
        dialogue.name = "Valerius Vulcanius";


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
