using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmatusReward : BaseState
{
    Dialogue dialogue;
    string sentence1 = "You could do better. As such, I'm afraid theres no reward.";
    string sentence2 = "Well done, you really know your stuff!";
    string sentence3 = "As such, Ill give you my secret on how to increase the damage you cause with your stabbing attack.";
    bool over60 = false;
    public ArmatusReward(NPC npc) : base(npc)
    {

        dialogue = new Dialogue();

        dialogue.HasTabletPuzzle = false;
        dialogue.ConversationComplete = false;
        dialogue.ForcedDialogue = true;
        dialogue.name = "Gaius Armatus";


    }
    public override void EnterState()
    {
        GameManager manager = GameManager.Instance;
        over60 = manager.BattleQuizScore >= 60.0f;
        if (over60)
        {
            dialogue.sentences.Add(sentence2);
            dialogue.sentences.Add(sentence3);
            PlayerManager.Instance.IncreaseStabDamage();
        }
        else
        {
            dialogue.sentences.Add(sentence1);
        }


        npc.AssignDialogue(dialogue);
    }

    public override void UpdateState()
    {
        if (npc.GetHasConversationCompleted() && over60)
        {
            over60 = false;
            AudioManager.Instance.PlaySound("SwordSharpen");
        }
    }

    public override void FixedUpdateState()
    {

    }
}
