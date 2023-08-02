using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VulcaniusReward : BaseState
{
    Dialogue dialogue;
    string sentence1 = "You could do better. As such, I'm afraid theres no reward.";
    string sentence2 = "Well done, you really know your stuff!";
    string sentence3 = "As such, I'll make some improvement to your amour to make it lighter, making you a bit more fleet-footed.";
    int count = 0;
    public VulcaniusReward(NPC npc) : base(npc)
    {

        dialogue = new Dialogue();

        dialogue.HasTabletPuzzle = false;
        dialogue.ConversationComplete = false;
        dialogue.ForcedDialogue = true;
        dialogue.name = "Valerius Vulcanius";


    }
    public override void EnterState()
    {
        GameManager manager = GameManager.Instance;
        if (manager.WeaponsQuizScore >= 60.0f)
        {
            dialogue.sentences.Add(sentence2);
            dialogue.sentences.Add(sentence3);
            PlayerManager.Instance.IncreaseSpeed();
        }
        else
        {
            dialogue.sentences.Add(sentence1);
        }


        npc.AssignDialogue(dialogue);
    }

    public override void UpdateState()
    {
        if (npc.GetHasConversationCompleted() && count == 0)
        {
            count++;
            AudioManager.Instance.PlaySound("Anvil");
        }
    }

    public override void FixedUpdateState()
    {

    }
}
