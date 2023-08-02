using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaviusTabletOne : BaseState
{
    Dialogue dialogue;
    Tablet tablet;
    public FlaviusTabletOne(NPC npc) : base(npc)
    {
        string sentence1 = "Gauis Armatus says you did well on the training ground. It looks like your fit for duty!";
        string sentence2 = "I have some other tasks for you, you can read can't you?";
        string sentence3 = "Excellent, Ok well take a look at this message to make sure you can read Roman Cursive";
        string sentence4 = "Then you can deliver the message to the Fort Bath House Keeper, Vitalis.";
        string sentence5 = "You'll find Vitalis at the next building to the East.";

        dialogue = new Dialogue();
        dialogue.sentences.Add(sentence1);
        dialogue.sentences.Add(sentence2);
        dialogue.sentences.Add(sentence3);
        dialogue.sentences.Add(sentence4);
        dialogue.sentences.Add(sentence5);
        dialogue.HasTabletPuzzle = true;
        dialogue.name = "Flavius Cerialis";
        dialogue.ForcedDialogue = false;

        tablet = new Tablet();
        tablet.name = "Bath house Tablet";
        //  tablet.message = "The construction of the bathouse is taking too long. Get the building finished so our soldiers dont stink of hog!";
         tablet.message = "Test";
    }


    public override void EnterState()
    {
        Rigidbody2D rB = npc.GetComponent<Rigidbody2D>();
        rB.velocity = Vector3.zero;
        npc.AssignDialogue(dialogue);
        npc.AssignTablet(tablet);
        
    }

    public override void UpdateState()
    {
        if (npc.GetHasConversationCompleted())
        {
            FortGuide.Instance.SetObjectivecomplete(FortGuide.FortObjective.SpeakWithCommander);
        }
    }

    public override void FixedUpdateState()
    {

    }
}
