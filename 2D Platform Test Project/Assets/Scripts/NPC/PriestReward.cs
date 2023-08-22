using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestReward : BaseState
{
    Dialogue dialogue;
    string sentence1 = "You could do better. As such, I'm afraid theres no reward.";
    string sentence2 = "Well done, you really know your stuff!";
    string sentence3 = "As such, I'll bless you to give you more Vitality!";

    bool over60 = false;
    public PriestReward(NPC npc) : base(npc)
    {
       


        dialogue = new Dialogue();
        dialogue.HasTabletPuzzle = false;
        dialogue.ForcedDialogue = true;
        dialogue.ConversationComplete = false;
        dialogue.name = "Marcus Flavus";


    }

    public override void EnterState()
    {
        GameManager manager = GameManager.Instance;
        bool over60 = manager.GodsQuizScore >= 60.0f;
        if (over60)
        {
            dialogue.sentences.Add(sentence2);
            dialogue.sentences.Add(sentence3);
            PlayerManager.Instance.IncreaseVitality();
            AudioManager.Instance.PlaySound("Blessed");
        }
        else
        {
            dialogue.sentences.Add(sentence1);
        }


        npc.AssignDialogue(dialogue);
    }

    public override void UpdateState()
    {

    }

    public override void FixedUpdateState()
    {

    }
}
