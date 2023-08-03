using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LepidinaArtefactQuest : BaseState
{
    Dialogue dialogue;
    public LepidinaArtefactQuest(NPC npc) : base(npc)
    {
        string sentence1 = "Oh fantastic, the bathhouse is finally finished! My dear friend Claudia will be ever so envious.";
        string sentence2 = "I am Lady Lepidina, I'm married to Flavius Cerialis, the fort Commander.";
        string sentence3 = "I've noticed that the fort is getting incredibly messy. Plus, I've managed to mislay my slippers.";
        string sentence4 = "Would you be able to collect all the chests lying about and find my shoes!?";
        string sentence5 = "Once you found all the chests, come back to me and I'll test you on them. Thank you so much!";

        dialogue = new Dialogue();
        dialogue.sentences.Add(sentence1);
        dialogue.sentences.Add(sentence2);
        dialogue.sentences.Add(sentence3);
        dialogue.sentences.Add(sentence4);
        dialogue.sentences.Add(sentence5);

        dialogue.HasTabletPuzzle = false;
        dialogue.ForcedDialogue = true;
        dialogue.name = "Lady Lepidina";

    }

    int count = 0;
    public override void EnterState()
    {
        npc.AssignDialogue(dialogue);
        Rigidbody2D rB = npc.GetComponent<Rigidbody2D>();
        rB.velocity = Vector3.zero;
        ArtefactCanvasManager.Instance.ActivateChests();
    }

    public override void UpdateState()
    {
        if(npc.GetHasConversationCompleted() && count == 0)
        {
            count++;
            FortGuide.Instance.SetObjectivecomplete(FortGuide.FortObjective.GetLumber);
        }
    }

    public override void FixedUpdateState()
    {


    }
}
