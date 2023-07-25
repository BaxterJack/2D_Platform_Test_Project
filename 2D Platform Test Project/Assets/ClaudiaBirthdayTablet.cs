using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaudiaBirthdayTablet : BaseState
{
    Dialogue dialogue;
    Tablet tablet;
    public ClaudiaBirthdayTablet(NPC npc) : base(npc)
    {
        string sentence1 = "Thank you so much for saving us!";
        string sentence2 = "Now that the way is safe, would you be able to deliver this message to my dear friend Lady Lepidina?";

      
        dialogue = new Dialogue();
        dialogue.sentences.Add(sentence1);
        dialogue.sentences.Add(sentence2);
        dialogue.HasTabletPuzzle = true;
        dialogue.ForcedDialogue = true;
        dialogue.name = "Claudia Severa";
        tablet = new Tablet();
        tablet.name = "Birthday Invitation";
        //tablet.message = "I give you a warm invitation to my birthday celebration to make sure that you come to us," +
        //    " to make the day more enjoyable for me by your arrival. Give my greetings to your Cerialis." +
        //    " I shall expect you, sister. Farewell, sister, my dearest soul, as I hope to prosper, and hail.";
        tablet.message = "Test";

    }


    public override void EnterState()
    {
        npc.AssignDialogue(dialogue);
        npc.AssignTablet(tablet);
        Rigidbody2D rB = npc.GetComponent<Rigidbody2D>();
        rB.velocity = Vector3.zero;
    }

    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {

    }
}
